using AppData.Entities;
using AppData.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository.Implement
{
    public class VeMayBayRepo : IVeMayBayRepo
    {
        private readonly AppDbContext _context;
        public VeMayBayRepo(AppDbContext context)
        {
            _context = context; 
        }

        public async Task AddAsync(VeMayBay veMayBay)
        {
            veMayBay.Id = Guid.NewGuid();
            _context.VeMayBays.Add(veMayBay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var veMayBay = await _context.VeMayBays.FindAsync(id);
            if (veMayBay != null)
            {
                _context.VeMayBays.Remove(veMayBay);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VeMayBay>> GetAllAsync()
        {
            return await _context.VeMayBays.ToListAsync();
        }

        public async Task<VeMayBay> GetIdAssync(Guid id)
        {
            return await _context.VeMayBays.FindAsync(id);
        }

        public Task<decimal> TinhToanVeMayBayAsync(int quantity, decimal pricePerTicket)
        {
            return Task.FromResult(quantity * pricePerTicket);
        }

        public async Task UpdateAsync(VeMayBay veMayBay)
        {
            _context.VeMayBays.Update(veMayBay);
            await _context.SaveChangesAsync();
        }
    }
}
