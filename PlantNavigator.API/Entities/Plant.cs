﻿using PlantNavigator.API.Entities.JoinEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNavigator.API.Entities
{
    public class Plant : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public WaterCondition? WaterCondition { get; set; } 
        public int WaterConditionId { get; set; }

        public List<Plant_Soil> Plant_Soils { get; set; }
    }
}
