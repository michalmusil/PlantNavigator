﻿
using PlantNavigator.API.Entities.Enums;

namespace PlantNavigator.API.Models.DTOs.Get
{
    public class PlantGetDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Month? FloweringFrom { get; set; }
        public Month? FloweringTo { get; set; }
        public bool? MistingAppropriate { get; set; }

        public WaterConditionGetDto? WaterCondition { get; set; }

        public LightConditionGetDto? LightCondition { get; set; }

    }
}
