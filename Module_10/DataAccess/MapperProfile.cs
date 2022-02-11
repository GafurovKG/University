namespace DataAccess
{
    using AutoMapper;
    using DataAccess.Models;
    using Domain.Models;

    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<StudentDb, Student>().ReverseMap();
            CreateMap<LectorDb, Lector>().ReverseMap();
            CreateMap<LectureDb, Lecture>().ReverseMap();
            CreateMap<HomeWorkDb, HomeWork>().ReverseMap();
        }
    }
}