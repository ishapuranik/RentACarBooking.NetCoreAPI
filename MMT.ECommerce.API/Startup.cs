using Bookings.Shared.Config;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Bookings.API.Core;
using Bookings.Persistence;
using Bookings.Services.TokenServices;
using Bookings.Shared.Log;
using Bookings.Shared.Persistance;
using Bookings.Shared.Tools;
using System.Reflection;
using Bookings.Shared.Persistence;
using Bookings.Persistence.Repositories.Renters;
using Bookings.Domain.Repositories.BookingStatuses;
using Bookings.Domain.Repositories.Vehicles;
using Bookings.Domain.Repositories.VehicleTypes;

namespace Booking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(Configuration.GetSection("ClientOriginUrls")
                        .AsEnumerable()
                        .Select(c => c.Value)
                        .Where(v => !v.IsNullOrEmpty())
                        .ToArray())
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers().AddNewtonsoftJson();
            ConfigureSwagger(services);

            ConfigurePersistance(services);

            services.AddScoped<ILogWrapper, NLogWrapper>((ctx) =>
                new NLogWrapper(Configuration.GetConnectionString(DbConfig.CONNECTION_STRING_ORDERS_DB)));

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IConfigWrapper, ConfigWrapper>();

            ConfigureApis(services);
            ConfigureAuthorization(services);
            ConfigureValidators(services);
            ConfigureAutoMapper(services);
            ConfigureRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookings.API v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void ConfigureSwagger(IServiceCollection services)
        {
            if (Configuration["Swagger:Enable"] == "true")
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bookings.API", Version = "v1" });
                    c.IncludeXmlComments(xmlPath);
                });
            }
        }

        private void ConfigureApis(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<HttpClient, HttpClient>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IRenterRepository, RenterRepository>();
            services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var autoMapperProfiles = GetAutoMapperProfiles(typeof(Startup));
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                foreach (var profile in autoMapperProfiles)
                {
                    mc.AddProfile(profile);
                }
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private List<Profile> GetAutoMapperProfiles(Type type)
        {
            var currentAssembly = Assembly.GetAssembly(type);
            var assembliesTypes = currentAssembly.GetTypes()
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct();

            var autoMapperProfiles = assembliesTypes.Select(p => (Profile)Activator.CreateInstance(p)).ToList();

            return autoMapperProfiles;
        }

        private void ConfigurePersistance(IServiceCollection services)
        {
            services.AddDbContext<RentACarDBContext>(option =>
            {
                option = new DbContextOptionsBuilder<RentACarDBContext>()
                    .UseSqlServer(Configuration.GetConnectionString(DbConfig.CONNECTION_STRING_ORDERS_DB));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            
        }
    }
}
