using Microsoft.Extensions.DependencyInjection;
using TradeApi.Application.Interfaces.AutoMapper;

namespace TradeApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
