using MyULibrary_API.DTOs;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyULibrary_API.Interfaces
{
    public interface ILoansRepository
    {
        Task<LoanHistory> createLoan(LoanHistory loan);
        Task<LoanHistory> returnLoan(LoanHistory loan);
        Task<IEnumerable<LoanHistoryDTo>> getAllLoans();
        Task<LoanHistory> getLoansByUser(int idUser);
        Task<IEnumerable<LoanHistory>> getLoanHistoryByUser(int idUser);
    }
}
