using ECommerce.API.Repositories.Interfaces;
using ECommerce.Models;

namespace ECommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public static List<Usuario> _db = new();

        public List<Usuario> Get()
        {
            return _db;
        }

        public Usuario Get(int id)
        {
            return _db.FirstOrDefault(u => u.Id.Equals(id))!;
        }

        public void Add(Usuario usuario)
        {
            _db.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            Delete(usuario.Id);
            Add(usuario);
        }

        public bool Delete(int id)
        {
            var usuario = Get(id);

            if (usuario == null)
                return false;

            _db.Remove(usuario);

            return true;
        }
    }
}
