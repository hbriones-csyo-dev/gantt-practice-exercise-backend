using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gantt_practice_exercise_backend.Models
{
    [Table("ProjectTaskLink")]
    public class ProjectTaskLink
    {
        [Required]
        [Key]
        public string? Id { get; set; }

        [Required]
        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [Required]
        [JsonPropertyName("target")]
        public string? Target { get; set; }

        [Required]
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
