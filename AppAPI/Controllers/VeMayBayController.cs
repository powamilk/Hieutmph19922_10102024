using AppData.Entities;
using AppData.Repository.Implement;
using AppData.Repository.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeMayBayController : ControllerBase
    {
        private readonly IVeMayBayRepo _repository;
        private readonly IValidator<VeMayBay> _validator;

        public VeMayBayController(IVeMayBayRepo repository, IValidator<VeMayBay> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeMayBay>>> GetAll()
        {
            var veMayBays = await _repository.GetAllAsync();
            return Ok(veMayBays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeMayBay>> GetById(Guid id)
        {
            var veMayBay = await _repository.GetByIdAsync(id);
            if (veMayBay == null)
            {
                return NotFound();
            }
            return Ok(veMayBay);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] VeMayBay veMayBay)
        {
            var validationResult = await _validator.ValidateAsync(veMayBay);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                }));
            }

            var createdVeMayBay = await _repository.AddAsync(veMayBay);
            return CreatedAtAction(nameof(GetById), new { id = createdVeMayBay.Id }, createdVeMayBay);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] VeMayBay veMayBay)
        {
            var validationResult = await _validator.ValidateAsync(veMayBay);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                }));
            }

            var result = await _repository.UpdateAsync(id, veMayBay);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("tonggia")]
        public async Task<ActionResult<decimal>> TinhTongGiaVe(int quantity, decimal pricePerTicket)
        {
            var totalPrice = await _repository.TinhToanVeMayBayAsync(quantity, pricePerTicket);
            return Ok(totalPrice);
        }
    }
}
