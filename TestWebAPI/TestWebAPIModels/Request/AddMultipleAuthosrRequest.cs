using TestWebAPI.Model.Request;
using TestWebAPIModels.Models;

 namespace TestWebAPIModel.Request
{
    public class AddMultipleAuthosrRequest 
    {
        public IEnumerable<AddAuthorRequest> AuthorRequest { get; set; }
        public string Reason { get; set; }

        public string Name { get; set; }

    }
}
