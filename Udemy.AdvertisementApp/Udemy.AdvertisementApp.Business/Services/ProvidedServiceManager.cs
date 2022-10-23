using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Business.Interfaces;
using Udemy.AdvertisementApp.DataAccess.UnitOfWork;
using Udemy.AdvertisementApp.Dtos;
using Udemy.AdvertisementApp.Entities;

namespace Udemy.AdvertisementApp.Business.Services
{
    public class ProvidedServiceManager:Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>,IProvidedService
    {
        public ProvidedServiceManager(IMapper mapper,IValidator<ProvidedServiceCreateDto>createDtoValidator,IValidator<ProvidedServiceUpdateDto>updateDtoValidator,IUow uow):base(mapper, createDtoValidator, updateDtoValidator,uow)
        {

        }
    }
}
