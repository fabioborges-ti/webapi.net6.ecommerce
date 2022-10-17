using ECommerce.Models;

namespace ECommerce.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task<Usuario> Add(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
