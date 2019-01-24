using Application.DTOs;
using Application.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.IRepositories;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioPerfilService : IUsuarioPerfilService
    {
        IUsuarioPerfilRepository repository;
        public UsuarioPerfilService(IUsuarioPerfilRepository repo)
        {
            repository = repo;
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }
        
        public IList<UsuarioPerfilDTO> GetAll()
        {
            IQueryable<TUsuarioperfil> gruposEntities= repository.Items;

            return Builders.
                   GenericBuilder.
                   builderListEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>
                   (gruposEntities);
        }

        public UsuarioPerfilDTO GetUsuarioPerfil(Guid Id)
        {
            var entity = repository.Items.Where(u => u.UsuperId == Id).FirstOrDefault();
            return Builders.
                  GenericBuilder.
                  builderEntityDTO<UsuarioPerfilDTO, TUsuarioperfil>
                  (entity);
        }

        public void Insert(UsuarioPerfilDTO entityDTO)
        {
            TUsuarioperfil entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public async Task InsertWithID(UsuarioPerfilDTO entityDTO)
        {
            TUsuarioperfil entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                        (entityDTO);
            await repository.SaveWithId(entity);
        }

        public void Update(UsuarioPerfilDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TUsuarioperfil, UsuarioPerfilDTO>
                (entityDTO);
            repository.Save(entity);
        }

    }
}
