using AutoMapper;
using CarAssembly.Database.Models;
using CarAssembly.ModelDtos.Assembly;
using CarAssembly.ModelDtos.CarDtos;

namespace CarAssembly.Extentions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mappin for cars
            this.CreateMap<AssemblyFormDto, Assembly>();
            this.CreateMap<Assembly, AssemblyFormDto>();
            this.CreateMap<Car, CarFromDto>();
            this.CreateMap<CarFromDto, Car>();
        }
    }
}
