namespace Runner.Infrastructure.Mappings
{
    using Runner.Application;
    using AutoMapper;

    public class OutputConverter : IOutputConverter
    {
        private readonly IMapper mapper;

        public OutputConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<CleanTemplateProfile>();
                cfg.AddProfile<EventSourcingTemplateProfile>();
                cfg.AddProfile<HexagonalTemplateProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
