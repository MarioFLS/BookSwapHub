using System.ComponentModel.DataAnnotations;

namespace BookSwapHub.API.Core.Models.BaseDate
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = default!;
        public DateTime UpdatedAt { get; set; } = default!;
    }
}