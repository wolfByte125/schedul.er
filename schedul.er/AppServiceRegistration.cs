using schedul.er.Services.EventServices;
using schedul.er.Services.EventTypeServices;
using System.Runtime.CompilerServices;

namespace schedul.er
{
    public static class AppServiceRegistration
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IEventService, EventService>();
        }
    }
}
