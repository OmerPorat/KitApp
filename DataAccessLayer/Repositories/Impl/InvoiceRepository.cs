using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using InvoiceOrchestrator.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories.Impl
{
    public class InvoiceRepository: IInvoiceRepository
    {
        
        private readonly InvoiceContext _context = null;


        public InvoiceRepository(IOptions<MongoConfigurations> settings)
        {
            _context = new InvoiceContext(settings);
        }

        public async Task<Invoice> GetInvoice(string id)
        {
            try
            {
                Guid internalId =Guid.NewGuid();
                return await _context.Invoices
                    .Find(invoice => invoice.SupplierId == id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddInvoice(Invoice item)
        {
            try
            {
                await _context.Invoices.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task<bool> RemoveInvoice(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}