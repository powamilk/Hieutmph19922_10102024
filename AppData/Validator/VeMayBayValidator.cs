using AppData.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Validator
{
    public class VeMayBayValidator : AbstractValidator<VeMayBay>
    {
        public VeMayBayValidator()
        {
            RuleFor(v => v.TenKhachHang)
                .NotEmpty().WithMessage("Tên hành khách không được để trống.");

            RuleFor(v => v.SoHieuChuyenBay)
                .NotEmpty().WithMessage("Số hiệu chuyến bay không được để trống.");

            RuleFor(v => v.NgayBay)
                .GreaterThan(DateTime.Now).WithMessage("Ngày bay phải là một ngày trong tương lai.");

            RuleFor(v => v.GiaVe)
                .GreaterThan(0).WithMessage("Giá vé phải lớn hơn 0.");
        }
    }
}
