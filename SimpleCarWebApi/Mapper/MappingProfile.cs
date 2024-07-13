using AutoMapper;
using SimpleCarWebApi.Dto;
using SimpleCarWebApi.Models;

namespace SimpleCarWebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<CarBrand, CarBrandDto>();
            CreateMap<CarBodyType, CarBodyTypeDto>();

            CreateMap<CarDto, Car>();
            CreateMap<CarBrandDto, CarBrand>();
            CreateMap<CarBodyTypeDto, CarBodyType>();
        }
    }
}
