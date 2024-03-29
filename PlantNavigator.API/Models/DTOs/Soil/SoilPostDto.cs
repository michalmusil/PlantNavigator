﻿using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.Soil
{
    public class SoilPostDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
