using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class LoansRepository : ILoansRepository
    {
        public Task<LoanHistory> createLoan(LoanHistory loan)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<LoanHistory>> getAllLoans()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<LoanHistory>> getLoanHistoryByUser(int idUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<LoanHistory> getLoansByUser(int idUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<LoanHistory> returnLoan(LoanHistory loan)
        {
            throw new System.NotImplementedException();
        }
    }
}
