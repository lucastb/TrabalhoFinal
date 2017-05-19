using System;
using System.Collections.Generic;
using System.Text;
using PL.Model;
using PL.Model.POCO;

namespace PL.DAO
{
    public interface IUsuario : IDisposable
    {
        IEnumerable<Usuario> getUsuarios();
        Usuario GetAUsuarioByID(int userID);
        void Add(Usuario usuario);
        void Delete(int usuarioID);
        void Update(Usuario user);
    }
}
