using TestWebAPIModels.Models;

 namespace TestWebAPIModel.Request
{
    public class AddAuthorRequest 
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; init; }

        public string NickName { get; init; }

       

    }
}
