using CodiJobServices.Model.CodiJobDb;
using System.Linq;

namespace CodiJobServices.Model.Repositories
{
    public interface IProyectoRepository : IRepository<Tproyectos>
    {
        IQueryable<Tproyectos> FilterProyectos(int pageSize, int page);
    }
}
