﻿using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositorios.Interfaces;

namespace SistemaTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }
       
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados. ");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email; 

            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados. ");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
