namespace TaskRunnerApp.Infrastructure.Mappings
{
    using AutoMapper;
    using TaskRunnerApp.Application.UseCases.Runners;

    public class CleanTemplateProfile : Profile
    {
        public CleanTemplateProfile()
        {
            CreateMap<Application.UseCases.Runners.CleanTemplate.Input, RunOutput>()
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.OrderId));
        }
    }
}
