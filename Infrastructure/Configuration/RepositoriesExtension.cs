using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class RepositoriesExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDominioRepository, DominioRepository>();
            services.AddScoped<ICarreraRepository, CarreraRepository>();
            services.AddScoped<ICasaEstudioRepository, CasaEstudioRepository>();
            services.AddScoped<IAlumnoRepository, AlumnoRepository>();
            services.AddScoped<IProspectoRepository, ProspectoRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IKamRepository, KamRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITokenCorreoRepository, TokenCorreoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMotivoRepository, MotivoRepository>();
            services.AddScoped<IContactoRepository, ContactoRepository>();
            services.AddScoped<IPlantillaRepository, PlantillaRepository>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<ITipoPlantillaRepository, TipoPlantillaRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<ITareaRepository, TareaRepository>();




            return services;
        }
    }
}
