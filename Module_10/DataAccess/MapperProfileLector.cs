namespace DataAccess
{
    using AutoMapper;
    using Domain;
    using Domain.Models;

    internal class MapperProfileLecor : Profile
    {
        public MapperProfileLecor()
        {
            CreateMap<LectorDb, Lector>().ReverseMap();
        }
    }
}