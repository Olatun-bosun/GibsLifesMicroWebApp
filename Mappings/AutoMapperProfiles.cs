using AutoMapper;
using GibsLifesMicroWebApp.Model.Domain;
using GibsLifesMicroWebApp.Model.DTO;

namespace GibsLifesMicroWebApp.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PolicyMas, PolicyMasDto>().ReverseMap();
            CreateMap<AddPolicyMasRequest, PolicyMas>().ReverseMap();
            CreateMap<SubRisks, SubRisksDto>().ReverseMap();
        }
    }

}
