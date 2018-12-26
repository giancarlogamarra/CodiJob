using CodiJobServices.Domain;
using CodiJobServices.Domain.IRepositories;
using System;
using System.Linq;

namespace CodiJobServices.Model.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        public IQueryable<TProyecto> Items => context.TProyecto;
        private CodiJobDbContext context;
        public EFProyectoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TProyecto proyecto)
        {
            
            if (proyecto.ProId == Guid.Empty)
            {
                proyecto.ProId = Guid.NewGuid();
                context.TProyecto.Add(proyecto);
            }
            else
            {
                TProyecto dbEntry = context.TProyecto
                .FirstOrDefault(p => p.ProId == proyecto.ProId);
                if (dbEntry != null)
                {
                    dbEntry.ProdNom = proyecto.ProdNom;
                    dbEntry.ProdDesc = proyecto.ProdDesc;
                    dbEntry.ProdFecha = proyecto.ProdFecha;
                    dbEntry.ProdUrl = proyecto.ProdUrl;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid ProyectoID)
        {
            TProyecto dbEntry = context.TProyecto
            .FirstOrDefault(p => p.ProId == ProyectoID);
            if (dbEntry != null)
            {
                context.TProyecto.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public IQueryable<TProyecto> FilterProyectos(int pageSize, int page)
        {
            return this.Items
              .Skip((page - 1) * pageSize)
              .Take(pageSize);
        }
    }
}
