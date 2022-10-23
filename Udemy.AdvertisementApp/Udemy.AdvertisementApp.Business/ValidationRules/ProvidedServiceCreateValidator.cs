using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos;

namespace Udemy.AdvertisementApp.Business.ValidationRules
{
    internal class ProvidedServiceCreateValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateValidator()
        {
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("250 karakterden fazla olamaz");
        }
    }
}
