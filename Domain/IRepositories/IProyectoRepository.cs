
using CodiJobServices.Domain;
using System.Linq;

namespace CodiJobServices.Domain.IRepositories
{
    public interface IProyectoRepository : IRepository<TProyecto>
    {
        IQueryable<TProyecto> FilterProyectos(int pageSize, int page);
    }
}
