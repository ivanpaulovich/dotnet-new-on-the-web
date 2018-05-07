namespace Cart.Infrastructure.Mappings
{
    using AutoMapper;
    using Cart.Application.UseCases.Orders;
    using Cart.Domain.Templates;

    public class EventSourcingTemplateProfile : Profile
    {
        public EventSourcingTemplateProfile()
        {
            CreateMap<EventSourcingTemplate, OrderOutput>()
                .ForMember(dest => dest.CommandLines, opt => opt.MapFrom(src => src.CommandLines))
                .ForMember(dest => dest.OrderUtcDate, opt => opt.MapFrom(src => src.OrderUtcDate))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
