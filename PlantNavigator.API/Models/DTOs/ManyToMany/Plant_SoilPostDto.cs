﻿using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.ManyToMany
{
    public class Plant_SoilPostDto
    {
        public string? Condition { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int SoilId { get; set; }
    }
}