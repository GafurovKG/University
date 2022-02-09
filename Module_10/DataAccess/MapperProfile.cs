namespace DataAccess
{
    using AutoMapper;
    using DataAccess.Models;
    using Domain.Models;

    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<TEntitySource, TEntityDist>().ReverseMap();
            CreateMap<StudentDb, Student>().ReverseMap();
            CreateMap<LectorDb, Lector>().ReverseMap();
        }
    }
}