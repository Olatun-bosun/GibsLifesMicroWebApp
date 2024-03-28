using AutoMapper;
using GibsLifesMicroWebApp.Data;
using GibsLifesMicroWebApp.Model.Domain;
using GibsLifesMicroWebApp.Model.DTO;
using GibsLifesMicroWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GibsLifesMicroWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyMasterController : ControllerBase
    {

        private readonly DataContext dbContext;
        private readonly IPolicyMasRepository policyMasRepository;
        private readonly IMapper mapper;

        public PolicyMasterController(DataContext dbContext, IPolicyMasRepository policyMasRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.policyMasRepository = policyMasRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var policysMasDomain = await policyMasRepository.GetAllAsync();

            var policyMasDto = mapper.Map<List<PolicyMasDto>>(policysMasDomain);

            return Ok(policyMasDto);
        }

        [HttpGet]
        [Route("{policyID}")]
        public async Task<IActionResult> GetByPolicyID([FromRoute] long policyID)
        {
            //var policy = dbContext.Policies.Find(policyNo);   
            var policyMasDomain = await policyMasRepository.GetByPolicyIDAsync(policyID);
            if (policyMasDomain == null)
            {
                return NotFound();
            }

            var policyMasDto = mapper.Map<PolicyMasDto>(policyMasDomain);

            return Ok(policyMasDto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPolicyMasRequest addPolicyMasRequest)
        {
            var policyMasDomainModel = mapper.Map<PolicyMas>(addPolicyMasRequest);
            policyMasDomainModel = await policyMasRepository.CreateAsync(policyMasDomainModel);

            var policyMasDto = mapper.Map<PolicyMasDto>(policyMasDomainModel);

            return CreatedAtAction(nameof(GetByPolicyID), new { policyID = policyMasDomainModel.PolicyID }, policyMasDomainModel);

        }
    }
}
