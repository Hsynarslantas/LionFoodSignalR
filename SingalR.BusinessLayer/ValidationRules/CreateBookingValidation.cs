using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SingalR.DtoLayer.BookingDto;

namespace SingalR.BusinessLayer.ValidationRules
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez !");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez !");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez !");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısı Alanı Boş Geçilemez !");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez !");


            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim Alanına En Az 5 Karakter Girişi Yapınız !");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim Alanına En Fazla 50 Karakter Girişi Yapınız !");
            RuleFor(x => x.Description).MinimumLength(100).WithMessage("Açıklama Alanına En Az 100 Karakter Girişi Yapınız !");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz !");
        }
    }
}
