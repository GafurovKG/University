namespace DataAccess
{
    using AutoMapper;
    using Domain;

    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDb, Student>().ReverseMap();
        }
    }
}