namespace Runner.Infrastructure.Mappings
{
    using AutoMapper;
    using Runner.Application.UseCases.Orders;
    using Runner.Application.UseCases.Runners;
    using Runner.Domain.Templates;

    public class TemplatesProfile : Profile
    {
        public TemplatesProfile()
        {
            CreateMap<CleanTemplate, OrderOutput>()
                .ForMember(dest => dest.OrderUtcDate, opt => opt.MapFrom(src => src.OrderUtcDate))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CleanTemplate, RunOutput>()
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
