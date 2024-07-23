using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace user_app.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Title { get; set; }
        [Required]
        [MinLength(3)]
        public required string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public ImmutableList<TagModel> Tags { get; set; } = [];
    }
}