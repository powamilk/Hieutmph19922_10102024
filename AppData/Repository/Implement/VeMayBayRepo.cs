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

        public async Task<VeMayBay> AddAsync(VeMayBay veMayBay)
        {
            veMayBay.Id = Guid.NewGuid();
            _context.VeMayBays.Add(veMayBay);
            await _context.SaveChangesAsync();
            return veMayBay;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingVeMayBay = await GetByIdAsync(id);
            if (existingVeMayBay == null) return false;

            _context.VeMayBays.Remove(existingVeMayBay);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<VeMayBay>> GetAllAsync()
        {
            return await _context.VeMayBays.ToListAsync();
        }

        public async Task<VeMayBay> GetByIdAsync(Guid id)
        {
            return await _context.VeMayBays.FindAsync(id);
        }

        public Task<decimal> TinhToanVeMayBayAsync(int quantity, decimal pricePerTicket)
        {
            return Task.FromResult(quantity * pricePerTicket);
        }

        public async Task<bool> UpdateAsync(Guid id, VeMayBay veMayBay)
        {
            var existingVeMayBay = await GetByIdAsync(id);
            if (existingVeMayBay == null) return false;

            _context.Entry(existingVeMayBay).CurrentValues.SetValues(veMayBay);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
