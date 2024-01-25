using AnimeTV.BackEnd.DataContext;
using AnimeTV.BackEnd.Helpers;
using AnimeTV.BackEnd.Models;
using AnimeTV.BackEnd.Models.Usuario;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AnimeTV.BackEnd.Service.UsuarioService
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Usuario>> Authenticate(Usuario usuarioObj)
        {
            ServiceResponse<Usuario> response = new ServiceResponse<Usuario>();
            try
            {
                if (usuarioObj == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Usuário não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuarioObj.Email);

                if (!PasswordHasher.VerificarPassword(usuarioObj.Senha, usuario.Senha))
                {
                    response.Dados = null;
                    response.Mensagem = "Senha incorreta!";
                    response.Sucesso = false;
                    return response;
                }
                else
                {
                    response.Dados = null;
                    response.Mensagem = "Login Realizado!";
                    response.Sucesso = true;
                    return response;
                }
               
                response.Dados = usuario;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
        public async Task<ServiceResponse<List<Usuario>>> CreateUsuario(Usuario usuarioNovo)
        {
            ServiceResponse<List<Usuario>> response = new ServiceResponse<List<Usuario>>();
            try
            {
                if (usuarioNovo == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Informar dados!";
                    response.Sucesso = false;
                    return response;

                }
                if (await CheckEmailExistAsync(usuarioNovo.Email))
                {
                    response.Dados = null;
                    response.Mensagem = "E-mail já cadastrado.";
                    response.Sucesso = false;
                    return response;
                }
                usuarioNovo.Senha = PasswordHasher.HashPassword(usuarioNovo.Senha);
                usuarioNovo.Role = "User";
                usuarioNovo.Token = "";



                _context.Add(usuarioNovo);
                await _context.SaveChangesAsync();
                response.Mensagem = "Cadastro Realizado!";
                response.Dados = _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Usuario>>> DeleteUsuario(int id)
        {
            ServiceResponse<List<Usuario>> response = new ServiceResponse<List<Usuario>>();
            try
            {
                Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
                if (usuario == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Usuário não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
                response.Dados = _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<Usuario>> GetUsuarioById(int id)
        {
            ServiceResponse<Usuario> response = new ServiceResponse<Usuario>();
            try
            {
                 Usuario usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
                if (usuario == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Usuário não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                response.Dados = usuario;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Usuario>>> GetUsuarios()
        {
            ServiceResponse<List<Usuario>> response = new ServiceResponse<List<Usuario>>();
            try
            {
                response.Dados = _context.Usuarios.ToList();
                if (response.Dados.Count == 0)
                {
                    response.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Usuario>>> UpdateUsuario(Usuario usuarioEditado)
        {
            ServiceResponse<List<Usuario>> response = new ServiceResponse<List<Usuario>>();
            try
            {
                Usuario usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == usuarioEditado.Id);
                if (usuario == null)
                {
                    response.Dados = null;
                    response.Mensagem = "Usuário não localizado!";
                    response.Sucesso = false;
                    return response;

                }
                _context.Usuarios.Update(usuarioEditado);
                await _context.SaveChangesAsync();
                response.Dados = _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }
            return response;
        }
        private Task<bool> CheckEmailExistAsync(string email)
        {
           return  _context.Usuarios.AnyAsync(x => x.Email == email); 
        }
    }
}
