using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUsuarioPerfilService
    {
        void Insert(UsuarioPerfilDTO entityDTO);
        Task InsertWithID(UsuarioPerfilDTO entityDTO);
        IList<UsuarioPerfilDTO> GetAll();
        UsuarioPerfilDTO GetUsuarioPerfil(Guid Id);
        void Update(UsuarioPerfilDTO entityDTO);
        void Delete(Guid entityId);
    }
}
