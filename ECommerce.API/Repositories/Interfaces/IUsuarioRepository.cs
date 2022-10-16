using ECommerce.Models;

namespace ECommerce.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();
        Usuario Get(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        bool Delete(int id);
    }
}
