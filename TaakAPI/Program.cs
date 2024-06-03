
using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Services;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.Responses;
using Infrastructure.Middleware;

namespace TaakAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            var configuration = builder.Configuration;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", corsBuilder =>
                {
                    corsBuilder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        var errors = actionContext.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToList();

                        ResponseDto response = new(HttpStatusCode.BadRequest, "La solicitud no cumple con los criterios de aceptación");

                        return new BadRequestObjectResult(response);
                    };
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Taak API",
                    Description = ".NET 8 Web API"
                });
                // To Enable authorization using Swagger (JWT)

                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });

            builder.Services.AddSqlServerContexts(configuration);
            builder.Services.AddServices();
            builder.Services.AddRepositories();
            builder.Services.AddJwtAuthentication(configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseCors("EnableCORS");
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Public")),
                RequestPath = "/Public"
            });

            app.UseAuthorization();

            //TEST Middleware
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
