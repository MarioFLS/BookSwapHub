
using BookSwapHub.API.Core.Models.BaseDate;

namespace BookSwapHub.API.Core.Models
{

    public class User : BaseEntity
    {
        public string Nickname { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}