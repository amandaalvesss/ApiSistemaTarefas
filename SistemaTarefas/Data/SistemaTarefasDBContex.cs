﻿using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Models;
using System.Security.Cryptography.X509Certificates;

namespace SistemaTarefas.Data
{
    public class SistemaTarefasDBContex : DbContext
    {
       public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options) 
            : base(options)
        {                       
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
