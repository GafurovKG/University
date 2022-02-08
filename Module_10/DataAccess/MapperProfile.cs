namespace DataAccess
{
    using AutoMapper;
    using Domain;
    using Domain.Models;

    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<TEntitySource, TEntityDist>().ReverseMap();
            CreateMap<StudentDb, Student>().ReverseMap();
        }
    }
}