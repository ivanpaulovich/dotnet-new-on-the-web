namespace TaskRunnerApp.Infrastructure.Mappings
{
    using AutoMapper;
    using TaskRunnerApp.Application.UseCases.Runners;
    using TaskRunnerApp.Domain.Templates;

    public class EventSourcingTemplateProfile : Profile
    {
        public EventSourcingTemplateProfile()
        {
            CreateMap<Application.UseCases.Runners.EventSourcingTemplate.Input, RunOutput>()
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.OrderId));
        }
    }
}
