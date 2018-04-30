namespace OrdersWebApi.Infrastructure.Mappings
{
    using AutoMapper;
    using OrdersWebApi.Application.UseCases.Orders;
    using OrdersWebApi.Domain.Templates;

    public class CleanTemplateProfile : Profile
    {
        public CleanTemplateProfile()
        {
            CreateMap<CleanTemplate, OrderOutput>()
                .ForMember(dest => dest.CommandLines, opt => opt.MapFrom(src => src.GetCommandlines()))
                .ForMember(dest => dest.OrderUtcDate, opt => opt.MapFrom(src => src.OrderUtcDate))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
