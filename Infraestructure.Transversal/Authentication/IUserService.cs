﻿using Application.DTOs;
using Application.DTOs.CustomDTO;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public interface IUserService
    {
        Task<UsuarioPerfilDTO> AuthenticateAsync(string username, string password);
        Task AddUserAsync(AddUserDTO dto);
    }
}
