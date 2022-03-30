using AutoMapper;
using System;

namespace UserManagement.Service.Mappings
{
    public static class CustomObjectMapper
    {
        public static class ObjectMapper
        {
            private static readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DtoMappings>();
                });

                return config.CreateMapper();
            });

            public static IMapper Mapper => _lazy.Value;
        }
    }
}
