using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPIModels.Models;

namespace TestWebAPIModel.Responses
{
    public class AddAuthorResponse : BaseResponse
    {
        public Author Author { get; set; }
    }
}
