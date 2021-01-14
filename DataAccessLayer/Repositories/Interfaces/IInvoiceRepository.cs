using System.Threading.Tasks;
using DataAccessLayer.Models;
using MongoDB.Bson;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {

        Task<Kit> GetKitByName(string name);
        
        // add new note document
        Task AddKit(Kit kit);

        // remove a single document / note
        Task<bool> RemoveKit(string name);

        Task<bool> UpdateKit(Kit kit);


    }
}