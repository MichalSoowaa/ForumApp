using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Queries.DTOs
{
    public sealed record AnswerDetailsDTO(string Content, string Author, DateTime CreationDate);
}
