namespace Tracking.Infrastructure.Mappings
{
    using AutoMapper;
    using Tracking.Application.UseCases.TrackOrder;

    public class TrackingProfile : Profile
    {
        public TrackingProfile()
        {
            CreateMap<Domain.Tracking.Order, TrackingOutput>()
                .ForMember(dest => dest.CommandLines, opt => opt.MapFrom(src => src.CommandLines))
                .ForMember(dest => dest.DotNetNewFinishedUtcDate, opt => opt.MapFrom(src => src.DotNetNewFinishedUtcDate))
                .ForMember(dest => dest.DotNetNewOutput, opt => opt.MapFrom(src => src.DotNetNewOutput))
                .ForMember(dest => dest.DotNetNewStartedUtcDate, opt => opt.MapFrom(src => src.DotNetNewStartedUtcDate))
                .ForMember(dest => dest.DownloadUrl, opt => opt.MapFrom(src => src.UploadLink))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderReceivedUtcDate, opt => opt.MapFrom(src => src.OrderReceivedUtcDate))
                .ForMember(dest => dest.UploadFinished, opt => opt.MapFrom(src => src.UploadFinished));
        }
    }
}
