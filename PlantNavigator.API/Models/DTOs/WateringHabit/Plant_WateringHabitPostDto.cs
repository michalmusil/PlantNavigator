﻿using System.ComponentModel.DataAnnotations;

namespace PlantNavigator.API.Models.DTOs.WateringHabit
{
    public class Plant_WateringHabitPostDto
    {
        public string? Description { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int WateringHabitId { get; set; }
    }
}
