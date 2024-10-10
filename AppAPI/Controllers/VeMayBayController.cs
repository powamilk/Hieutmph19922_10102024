using AppData.Entities;
using AppData.Repository.Implement;
using AppData.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeMayBayController : ControllerBase
    {
        private readonly IVeMayBayRepo _veMayBayRepo;

        public VeMayBayController(IVeMayBayRepo veMayBayRepo)
        {
            _veMayBayRepo = veMayBayRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeMayBay>> GetById(Guid id)
        {
            var veMayBay = await _veMayBayRepo.GetIdAssync(id);
            if (veMayBay == null)
            {
                return NotFound();
            }
            return Ok(veMayBay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] VeMayBay veMayBay)
        {
            if(id != veMayBay.Id)
            {
                return BadRequest("Ve May Bay Ko ton Tai");    
            }
            var existinVeMayBay = await _veMayBayRepo.GetIdAssync(id);
            if (existinVeMayBay == null)
            {
                return NotFound();
            }    
            existinVeMayBay.TenKhachHang = veMayBay.TenKhachHang;
            existinVeMayBay.SoHieuChuyenBay = veMayBay.SoHieuChuyenBay;
            existinVeMayBay.NgayBay = veMayBay.NgayBay;
            existinVeMayBay.DiemDen = veMayBay.DiemDen;
            existinVeMayBay.DiemKhoiHanh = veMayBay.DiemKhoiHanh;
            existinVeMayBay.GiaVe = veMayBay.GiaVe; 

            await _veMayBayRepo.UpdateAsync(existinVeMayBay);
            return Ok();   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeMayBay>>> GetAll()
        {
            var veMayBays = await _veMayBayRepo.GetAllAsync();
            return Ok(veMayBays);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VeMayBay veMayBay)
        {
            await _veMayBayRepo.AddAsync(veMayBay);
            return CreatedAtAction(nameof(GetById), new { id = veMayBay.Id }, veMayBay);
        }


        [HttpGet("tonggia")]
        public async Task<ActionResult<decimal>> TinhTongGiaVe(int quantity, decimal pricePerTicket)
        {
            var totalPrice = await _veMayBayRepo.TinhToanVeMayBayAsync(quantity, pricePerTicket);
            return Ok(totalPrice);
        }
    }
}
