using System.ComponentModel.DataAnnotations;

namespace NZWalksApi.Models.DTO
{
    public class UpdateRegionDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Characters can not be less than 3")]
        [MaxLength(5, ErrorMessage = "Characters can not be more than 5")]
        public string? Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Characters can not be more than 100")]
        public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
