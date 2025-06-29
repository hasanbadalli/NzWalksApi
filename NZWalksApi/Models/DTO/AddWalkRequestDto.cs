﻿using System.ComponentModel.DataAnnotations;

namespace NZWalksApi.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        
        [Required]
        [Range(0, 100)]
        public double LengthInKM { get; set; }
        

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }
        
        [Required]
        public Guid RegionId { get; set; }
    }
}
