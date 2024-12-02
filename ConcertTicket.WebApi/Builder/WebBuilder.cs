using ConcertTicket.Application.DbContexts;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicket;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketAmphitheater;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketBalcony;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicket;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketAmphitheater;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketVip;
using ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket;
using ConcertTicket.WebApi.Models.DTOs;
using ConcertTicket.WebApi.Models.DTOs.CreateDTOs;
using ConcertTicket.WebApi.Models.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using PostgreDbPersistence.Contexts;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json.Serialization;

namespace ConcertTicket.WebApi.Builder
{
    public class WebBuilder
    {
        public static void AppBuild(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            //CORS
            builder.Services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            //Строка подключения
            string connect = builder.Configuration.GetConnectionString("SampleDbConnection");
            builder.Services.AddDbContext<TicketDbContext>(opt => opt.UseNpgsql(connect));

            //JSON
            builder.Services.AddControllers().AddJsonOptions(o => { o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; o.JsonSerializerOptions.MaxDepth = 0; });

            //Регистрация MediatR
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var applicationAssembly = Directory.GetFiles(path, "ConcertTicket.Application.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath).FirstOrDefault();
            builder.Services.AddMediatR(configuration => { configuration.RegisterServicesFromAssembly(applicationAssembly); });

            //Регистрация AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMapping(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMapping(typeof(TicketDbContext).Assembly));
            });

            //Регистрация Dependency Injection
            builder.Services.AddScoped<IPostgreDbContext, TicketDbContext>();

            builder.Services.AddScoped<IMapWith<CreateTicketVip>, CreateTicketVipDto>();
            builder.Services.AddScoped<IMapWith<CreateTicketBalcony>, CreateTicketBalconyDto>();
            builder.Services.AddScoped<IMapWith<CreateTicketAmphitheater>, CreateTicketAmphitheaterDto>();

            builder.Services.AddScoped<IMapWith<UpdateTicketVip>, UpdateTicketVipDto>();
            builder.Services.AddScoped<IMapWith<UpdateTicketBalcony>, UpdateTicketBalconyDto>();
            builder.Services.AddScoped<IMapWith<UpdateTicketAmphitheater>, UpdateTicketAmphitheaterDto>();

            //builder.Services.AddScoped<IMapWith<DeleteTicketVip>>();
            //builder.Services.AddScoped<IMapWith<DeleteTicketBalcony>>();
            //builder.Services.AddScoped<IMapWith<DeleteTicketAmphitheater>>();

            builder.Services.AddScoped<IMapWith<SearchTicket>, SearchTicketAmphitheaterDto>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
