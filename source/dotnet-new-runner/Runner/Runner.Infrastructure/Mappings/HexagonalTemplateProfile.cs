namespace Runner.Infrastructure.Mappings
{
    using AutoMapper;
    using Runner.Application.UseCases.Orders;
    using Runner.Application.UseCases.Runners;
    using Runner.Domain.Templates;

    public class HexagonalTemplateProfile : Profile
    {
        public HexagonalTemplateProfile()
        {
            CreateMap<CleanTemplate, OrderOutput>()
                .ForMember(dest => dest.CommandLines, opt => opt.MapFrom(src => src.GetCommandlines()))
                .ForMember(dest => dest.OrderUtcDate, opt => opt.MapFrom(src => src.OrderUtcDate))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Application.UseCases.Runners.HexagonalTemplate.Input, RunOutput>()
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.OrderId));
        }
    }
}
