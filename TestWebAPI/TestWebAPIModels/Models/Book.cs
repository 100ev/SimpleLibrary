using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPIModels.Models
{
    public record Book
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public int AuthorId { get; init; }
        public DateTime dateOfBirth { get; init; }
    }
}
