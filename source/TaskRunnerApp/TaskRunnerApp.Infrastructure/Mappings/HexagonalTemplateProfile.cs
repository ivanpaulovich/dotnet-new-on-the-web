namespace TaskRunnerApp.Infrastructure.Mappings
{
    using AutoMapper;
    using TaskRunnerApp.Application.UseCases.Runners;

    public class HexagonalTemplateProfile : Profile
    {
        public HexagonalTemplateProfile()
        {
            CreateMap<Application.UseCases.Runners.HexagonalTemplate.Input, RunOutput>()
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.OrderId));
        }
    }
}
