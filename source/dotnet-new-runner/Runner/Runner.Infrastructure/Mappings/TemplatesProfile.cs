namespace Runner.Infrastructure.Mappings
{
    using AutoMapper;
    using Runner.Application.Outputs;
    using Runner.Domain.Templates;

    public class TemplatesProfile : Profile
    {
        public TemplatesProfile()
        {
            CreateMap<CleanTemplate, GenerateOutput>()
                .ForMember(dest => dest.CommandLines, opt => opt.MapFrom(src => src.CommandLines))
                .ForMember(dest => dest.OrderUtcDate, opt => opt.MapFrom(src => src.OrderUtcDate))
                .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
