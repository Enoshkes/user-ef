using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace user_app.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public required string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public ImmutableList<PostModel> Posts { get; set; } = [];
    }
}