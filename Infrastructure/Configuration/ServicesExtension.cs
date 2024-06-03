
using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Services;
using Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDominioService, DominioService>();
            services.AddScoped<ICarreraService, CarreraService>();
            services.AddScoped<ICasaEstudioService, CasaEstudioService>();
            services.AddScoped<IAlumnoService, AlumnoService>();
            services.AddScoped<IProspectoService, ProspectoService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITokenCorreoService, TokenCorreoService>();
            services.AddScoped<IMotivoService, MotivoService>();
            services.AddScoped<IContactoService, ContactoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPlantillaService, PlantillaService>();
            services.AddScoped<IAnuncioService, AnuncioService>();
            services.AddScoped<ITipoPlantillaService, TipoPlantillaService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFTPService, FTPService>();
            services.AddScoped<ITareaService, TareaService>();

            return services;
        }
    }
}
