﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Models.DTOs.Classification;
using PlantNavigator.API.Repositories;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/classifications")]
    public class ClassificationsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IClassificationsRepository classificationsRepository;

        public ClassificationsController(ILogger<ClassificationsController> logger,
            IClassificationsRepository classificationsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.classificationsRepository = classificationsRepository ??
                throw new ArgumentNullException(nameof(classificationsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetClassifications")]
        public async Task<ActionResult<IEnumerable<ClassificationGetDto>>> GetClassifications([FromQuery] string? classificationName,
            int? plantId, bool? includeAsociatedPlants)
        {
            var classifications = await classificationsRepository.GetAll(classificationName, plantId, includeAsociatedPlants);
            return Ok(mapper.Map<IEnumerable<ClassificationGetDto>>(classifications));
        }

        [HttpGet("classificationTypes", Name = "GetClassificationTypes")]
        public async Task<ActionResult<IEnumerable<ClassificationType>>> GetClassificationTypes()
        {
            List<ClassificationTypeGetDto> classificationTypes = new List<ClassificationTypeGetDto>();
            foreach (int t in Enum.GetValues(typeof(ClassificationType)))
            {
                var type = new ClassificationTypeGetDto(t, Enum.GetName(typeof(ClassificationType), t));
                classificationTypes.Add(type);
            }
            return Ok(classificationTypes);
        }


        [HttpGet("{id}", Name = "GetClassificationById")]
        public async Task<ActionResult<ClassificationGetDto>> GetClassificationById(int id)
        {
            var classification = await classificationsRepository.GetById(id);

            if (classification == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClassificationGetDto>(classification));
        }



        [HttpPost(Name = "PostClassification")]
        public async Task<ActionResult> PostClassification(ClassificationPostDto classification)
        {
            Classification finalClassification = null;
            try
            {
                finalClassification = mapper.Map<Classification>(classification);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"User classification post not successfull: {ex.ToString}");
                return BadRequest();
            }

            await classificationsRepository.AddClassification(finalClassification);

            return CreatedAtRoute("GetClassificationById",
                new
                {
                    id = finalClassification.Id
                }, mapper.Map<ClassificationGetDto>(finalClassification));
        }

        [HttpPut("{id}", Name = "UpdateClassification")]
        public async Task<ActionResult> UpdateClassification(int id, ClassificationPutDto classification)
        {
            var foundClassification = await classificationsRepository.GetById(id);

            if (foundClassification == null)
            {
                return NotFound();
            }

            mapper.Map(classification, foundClassification);
            classificationsRepository.UpdateClassification(foundClassification);

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteClassificationById")]
        public async Task<ActionResult> DeleteClassificationById(int id)
        {
            var classification = await classificationsRepository.GetById(id);

            if (classification == null)
            {
                return NotFound();
            }

            await classificationsRepository.DeleteClassification(classification);
    
            return NoContent();
        }



        // PLANT TO CLASSIFICATION realted endpoints
        [HttpPost("plantClassification", Name = "PostPlantClassification")]
        public async Task<ActionResult> PostPlantClassification(Plant_ClassificationPostDto joining)
        {
            if (!await classificationsRepository.PlantExists(joining.PlantId))
            {
                return NotFound();
            }

            if (!await classificationsRepository.ClassificationExists(joining.ClassificationId))
            {
                return NotFound();
            }

            if (await classificationsRepository.GetPlantClassificationById(joining.PlantId, joining.ClassificationId) != null)
            {
                return BadRequest("This connection already exists");
            }

            try
            {
                var joinToAdd = mapper.Map<Plant_Classification>(joining);
                await classificationsRepository.AddPlantClassificationJoin(joinToAdd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("plantClassification", Name = "DeletePlantClassificationById")]
        public async Task<ActionResult> DeletePlantSoilById([FromQuery] int plantId, [FromQuery] int classificationId)
        {
            var plantClassification = await classificationsRepository.GetPlantClassificationById(plantId, classificationId);

            if (plantClassification == null)
            {
                return NotFound();
            }

            await classificationsRepository.DeletePlantClassification(plantClassification);

            return NoContent();
        }
    }
}
