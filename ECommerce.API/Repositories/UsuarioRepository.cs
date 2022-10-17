using ECommerce.API.Database;
using ECommerce.API.Repositories.Interfaces;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ECommerceContext _context;

        public UsuarioRepository(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> Get()
        {
            var result = await _context.Usuarios.ToListAsync();

            return result;
        }

        public async Task<Usuario> Get(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null!;

            return usuario;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            var obj = await Get(usuario.Id);

            if (obj == null)
                return null!;

            obj.Nome = usuario.Nome;
            obj.Email = usuario.Email;
            obj.Sexo = usuario.Sexo;
            obj.RG = usuario.RG;
            obj.CPF = usuario.CPF;
            obj.NomeMae = usuario.NomeMae;
            obj.SituacaoCadastro = usuario.SituacaoCadastro;

            _context.Usuarios.Update(obj);

            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await Get(id);

            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
