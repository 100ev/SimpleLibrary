using AutoMapper;
using TestWebAPI.Model.Request;
using TestWebAPIModel.Request;
using TestWebAPIModels.Models;

namespace TestWebAPI.AutoMapper
{
    class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<AddMultipleAuthosrRequest, Author>();
            CreateMap<AddBookRequest, Book>();
        }
    }
}
