using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Controllers
{
    [ApiController]
    [Route("api/pests")]
    public class PestsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger logger;
        private readonly IPestsRepository pestsRepository;

        public PestsController(ILogger<ClassificationsController> logger,
            IPestsRepository pestsRepository, IMapper mapper)
        {
            this.logger = logger ??
               throw new ArgumentNullException(nameof(logger));

            this.pestsRepository = pestsRepository ??
                throw new ArgumentNullException(nameof(pestsRepository));

            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


    }
}
