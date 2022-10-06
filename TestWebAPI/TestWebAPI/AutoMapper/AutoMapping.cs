using AutoMapper;
using TestWebAPI.Model.Request;
using TestWebAPI.Model.Responses;
using TestWebAPIModel.Request;
using TestWebAPIModels.Models;

namespace TestWebAPI.AutoMapper
{
    class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<AddMultipleAuthosrRequest, Author>();
            CreateMap<AddBookRequest, AddBookRequest>();
            CreateMap<Model.Request.AddBookRequest, Author>();
            CreateMap<Model.Request.AddBookRequest, AddBookResponse>();
        }
    }
}
