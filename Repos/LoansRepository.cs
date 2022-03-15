using Microsoft.EntityFrameworkCore;
using MyULibrary_API.DTOs;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class LoansRepository : ILoansRepository
    {
        private readonly MyULibraryContext _ctx;


        public LoansRepository(MyULibraryContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<LoanHistory> createLoan(LoanHistory loan)
        {
            loan.LoanDate = System.DateTime.Now;
            await _ctx.LoanHistories.AddAsync(loan);
            await _ctx.SaveChangesAsync();
            await updateStock(loan.BookId, "D");
            return loan;
        }

        public async Task<IEnumerable<LoanHistoryDTo>> getAllLoans()
        {
            List<LoanHistoryDTo> lista = await(from loan in _ctx.LoanHistories
                                        join user in _ctx.Users
                                        on loan.UserId equals user.UserId
                                        join book in _ctx.Books
                                        on loan.BookId equals book.BookID
                                        select new LoanHistoryDTo
                                        {
                                             BookId = loan.BookId,
                                             UserId = user.UserId,
                                             BookName = book.Title,
                                             LoanDate = loan.LoanDate,
                                             ReturnDate = loan.ReturnDate,
                                             UserName = user.FirstName+ " "+user.LastName,
                                        }).ToListAsync();
            return lista;
        }

        public Task<IEnumerable<LoanHistory>> getLoanHistoryByUser(int idUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<LoanHistory> getLoansByUser(int idUser)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LoanHistory> returnLoan(LoanHistory loan)
        {
            LoanHistory loanObj = _ctx.LoanHistories.Where(x => x.UserId == loan.UserId && x.LoanDate==loan.LoanDate && x.BookId == loan.BookId).FirstOrDefault();
            loanObj.ReturnDate = System.DateTime.Now;
            _ctx.LoanHistories.Update(loanObj);
            await _ctx.SaveChangesAsync();
            await updateStock(loan.BookId, "I");
            return loanObj;
        }
        //Update Stock after check out!
        private async Task<bool> updateStock(int bookId, string process) {
            try
            {
                Book book = _ctx.Books.Where(x => x.BookID == bookId).FirstOrDefault();
                if (process == "I")
                {
                    book.Stock++;
                }
                else { 
                    book.Stock--;   
                }
                _ctx.Books.Update(book);
                await _ctx.SaveChangesAsync();
                return true;

            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
