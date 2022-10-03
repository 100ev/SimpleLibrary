using AutoMapper;
using TestWebAPIModel.Request;
using TestWebAPIModels.Models;

namespace TestWebAPI.AutoMapper
{
    class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<AddAuthorRequest, Author>();
        }
    }
}
