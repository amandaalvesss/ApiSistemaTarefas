using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Repositorios;
using SistemaTarefas.Repositorios.Interfaces;
using System;

namespace SistemaTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration
                       .GetConnectionString("DataBase");

            builder.Services.AddDbContext<SistemaTarefasDBContex>(options =>
                              options
                              .UseMySql(connectionString,
                              ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}