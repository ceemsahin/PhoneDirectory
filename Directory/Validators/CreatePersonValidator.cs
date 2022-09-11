using Directory.Models;
using FluentValidation;

namespace Directory.Validators
{
    public class CreatePersonValidator : AbstractValidator<UserModel>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().NotEmpty().WithMessage("İsim ve soy isim boş geçilemez").MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla girmeyiniz.").MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz");




            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir telefon Numarası giriniz");
        }


    }
}
