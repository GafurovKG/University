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
            CreateMap<LectureUI, LectureDb>().ReverseMap();
            CreateMap<LectureUIPost, LectureDb>().ReverseMap();
            CreateMap<HomeWorkUI, HomeWorkDb>().ReverseMap();
            CreateMap<HomeWorkUIPost, HomeWorkDb>().ReverseMap();
            CreateMap<LectorUI, LectorDb>().ReverseMap();
            CreateMap<LectorUIPost, LectorDb>().ReverseMap();
        }
    }
}