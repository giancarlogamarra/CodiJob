

using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUsuarioPerfilRepository : IRepository<TUsuarioperfil>
    {
        void SaveWithId(TUsuarioperfil item);
    }
}
