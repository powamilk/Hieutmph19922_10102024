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
        Task<VeMayBay> GetIdAssync(Guid id);
        Task<IEnumerable<VeMayBay>> GetAllAsync(); 
        Task AddAsync(VeMayBay veMayBay);
        Task UpdateAsync(VeMayBay veMayBay);
        Task DeleteAsync(Guid id); 
        Task<decimal> TinhToanVeMayBayAsync(int quantity, decimal pricePerTicket);
    }
}
