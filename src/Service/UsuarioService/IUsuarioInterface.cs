﻿using AnimeTV.Models;
using AnimeTV.Models.Usuario;

namespace AnimeTV.Service.UsuarioService
{
    public interface IUsuarioInterface
    {
        Task<ServiceResponse<List<Usuario>>> GetUsuarios();
        Task<ServiceResponse<Usuario>> GetUsuarioById(int id);
        Task<ServiceResponse<Usuario>> Authenticate(Usuario usuarioObj);
        Task<ServiceResponse<List<Usuario>>> CreateUsuario(Usuario usuarioNovo);
        Task<ServiceResponse<List<Usuario>>> UpdateUsuario(Usuario usuarioEditado);
        Task<ServiceResponse<List<Usuario>>> DeleteUsuario(int id);
    }
}
