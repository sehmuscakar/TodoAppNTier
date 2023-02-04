using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Business.İnterfaces;
using Business.Mappings.AutoMapper;
using Business.Services;
using Business.ValidationRules;
using DataAccess.Contexts;
using DataAccess.UnitofWork;
using Dtos.WorkDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Business.Dependency
{
   public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)//IServiceCollection biz burda bunu genişletik,son kullanıcı en son busiinesi gürmeli dataaccess i görmemeli
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-O9RRR03;database=TodoDB_NTier; TrustServerCertificate=True; integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();//burda IUow gördüğünde Uow da algıla anlamında 
            services.AddScoped<IWorkService, WorkService>();


            services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();// Dependency Injection Aracılığı ile Validation ,ları tanımladık

			services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        }
    }
}
