using AutoMapper;
using GibsLifesMicroWebApp.Data;
using GibsLifesMicroWebApp.Model.DTO;
using GibsLifesMicroWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibsLifesMicroWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubRiskController : ControllerBase
    {
        private readonly DataContext dbContext;
        private readonly ISubRisksRepository SubRisksRepository;
        private readonly IMapper mapper;

        public SubRiskController(DataContext dbContext, ISubRisksRepository SubRisksRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.SubRisksRepository = SubRisksRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subrisksDomain = await SubRisksRepository.GetAllAsync();

            var SubRisksDto = mapper.Map<List<SubRisksDto>>(subrisksDomain);

            return Ok(SubRisksDto);
        }
    }
}
