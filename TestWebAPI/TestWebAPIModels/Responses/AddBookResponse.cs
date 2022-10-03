using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPIModel.Responses;
using TestWebAPIModels.Models;

namespace TestWebAPI.Model.Responses
{
    public class AddBookResponse : BaseResponse
    {
        public Book Title { get; set; }
    }
}
