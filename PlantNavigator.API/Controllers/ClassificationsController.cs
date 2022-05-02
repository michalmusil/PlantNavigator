using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Get;
using PlantNavigator.API.Models.DTOs.Post;
using PlantNavigator.API.Repositories;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/classifications")]
    public class ClassificationsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly ClassificationsRepository classificationsRepository;

        public ClassificationsController(ILogger<ClassificationsController> logger,
            ClassificationsRepository classificationsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.classificationsRepository = classificationsRepository ??
                throw new ArgumentNullException(nameof(classificationsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name ="GetClassifications")]
        public async Task<ActionResult<IEnumerable<ClassificationGetDto>>> GetClassifications()
        {
            var classifications = await classificationsRepository.GetAll();
            return Ok(mapper.Map<IEnumerable<ClassificationGetDto>>(classifications));
        }

        [HttpPost(Name = "PostClassification")]
        public async Task<ActionResult> PostClassification(ClassificationPostDto classification)
        {

        }
    }
}
