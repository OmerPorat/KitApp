using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {

        Task<Invoice> GetInvoice(string id);
        
        // add new note document
        Task AddInvoice(Invoice item);

        // remove a single document / note
        Task<bool> RemoveInvoice(string id);
        
        
    }
}