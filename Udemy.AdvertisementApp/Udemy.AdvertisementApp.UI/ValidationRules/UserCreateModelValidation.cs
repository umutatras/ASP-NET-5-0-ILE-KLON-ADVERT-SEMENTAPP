using FluentValidation;
using System;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidation:AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidation()
        {
            RuleFor(x=>x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(20);
            RuleFor(x => x.ConfirmPassword).MaximumLength(20);
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler aynı değil");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x =>          
                CannotFirstName(x.Username,x.Firstname))
            .WithMessage("kullanıcı adı 123 içeriyor").When(x=>x.Surname!=null&&x.Firstname!=null);
            
           
        }

        private bool CannotFirstName(string username, string firstname)
        {
        return !username.Contains(firstname);
            throw new NotImplementedException();
        }
    }
}
