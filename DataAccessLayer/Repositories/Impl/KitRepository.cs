using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using InvoiceOrchestrator.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Libmongocrypt;

namespace DataAccessLayer.Repositories.Impl
{
    public class KitRepository: IKitRepository
    {
        
        private readonly KitContext _context = null;


        public KitRepository(IOptions<MongoConfigurations> settings)
        {
            _context = new KitContext(settings);
        }
        
        public async Task<Kit> GetKitById(Guid id)
        {
            try
            {
                return await _context.Kits
                    .Find(kit => kit.KitId == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddKit(Kit kit)
        {
            try
            {
                await _context.Kits.InsertOneAsync(kit);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveKit(string name)
        {
            try
            {
               var a = await _context.Kits.DeleteOneAsync(doc => doc.KitName == name);
               return a.IsAcknowledged;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> UpdateKit(Kit kit)
        {

            var a = await _context.Kits.FindOneAndUpdateAsync<Kit>(doc => doc.KitName == kit.KitName, Builders<Kit>
                    .Update
                    .Set(doc => doc.Items, kit.Items)
                    .Set(doc => doc.KitName, kit.KitName),
                new FindOneAndUpdateOptions<Kit, Kit>{IsUpsert = true, ReturnDocument = ReturnDocument.After});
          return true;
        }
    }
}