using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositories;

namespace CodiJobServices.Model.Repositories
{
    public class EFGrupoRepository : IGrupoRepository
    {
        CodiJobDbContext Context;
        public EFGrupoRepository(CodiJobDbContext ctx) {
            this.Context = ctx;
        }

        public IQueryable<TGrupo> Items => Context.TGrupo;

        public void Delete(Guid itemId)
        {
            TGrupo dbEntry = Context.TGrupo
                .FirstOrDefault(p => p.Id == itemId);

            if (dbEntry != null)
            {
                Context.TGrupo.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TGrupo item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
                Context.TGrupo.Add(item);
            }
            else
            {
                TGrupo dbEntry = Context.TGrupo
                .FirstOrDefault(p => p.Id == item.Id);
                if (dbEntry != null)
                {
                    dbEntry.GrupoNom = item.GrupoNom;
                    dbEntry.GrupoFoto = item.GrupoFoto;
                    dbEntry.GrupoProm = item.GrupoProm;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}
