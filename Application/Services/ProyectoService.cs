using Application.DTOs;
using Application.IServices;
using CodiJobServices.Domain;
using CodiJobServices.Domain.IRepositories;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class ProyectoService : IProyectoService
    {
        IProyectoRepository repository;
        public ProyectoService(IProyectoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ProyectoDTO> GetAll()
        {
            return Builders.GenericBuilder.builderListEntityDTO<ProyectoDTO,TProyecto>(repository.Items);
        }

        public void Insert(ProyectoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TProyecto,ProyectoDTO>(entityDTO);
            repository.Save(entity);
        }

        public void Update(ProyectoDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TProyecto,ProyectoDTO>(entityDTO);
            repository.Save(entity);
        }
    }
}
