namespace WebApi
{
    using AutoMapper;
    using DataAccess.Models;
    using WebApi.UIModels;

    internal class MapperProfileUI : Profile
    {
        public MapperProfileUI()
        {
            CreateMap<StudentUI, StudentDb>().ReverseMap();
            CreateMap<StudentUIPost, StudentDb>().ReverseMap();
            CreateMap<LectureUIPost, LectureDb>().ReverseMap();
            CreateMap<HomeWorkUIPost, HomeWorkDb>().ReverseMap();
            CreateMap<LectorUIPost, LectorDb>().ReverseMap();
        }
    }
}