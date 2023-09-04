using AutoMapper;
using LayeredArchitectureApp.Data;
using LayeredArchitectureApp.DTO;

namespace LayeredArchitectureApp.Configuration
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CustomerCreateDTO, Customer>().ReverseMap();
            CreateMap<CustomerUpdateDTO, Customer>().ReverseMap();
            CreateMap<CustomerReadOnlyDTO, Customer>().ReverseMap();
        }
    }
}
