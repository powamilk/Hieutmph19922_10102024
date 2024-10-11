using AppData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository.Interface
{
    public interface IVeMayBayRepo
    {
        Task<IEnumerable<VeMayBay>> GetAllAsync();
        Task<VeMayBay> GetByIdAsync(Guid id);
        Task<VeMayBay> AddAsync(VeMayBay veMayBay);
        Task<bool> UpdateAsync(Guid id, VeMayBay veMayBay);
        Task<bool> DeleteAsync(Guid id);
        Task<decimal> TinhToanVeMayBayAsync(int quantity, decimal pricePerTicket);
    }
}
