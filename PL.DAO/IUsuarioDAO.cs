using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.DAO
{
    public interface IUsuarioDAO : IDisposable
    {
        IEnumerable<Usuario> getUsuarios();
        Usuario GetAUsuarioByID(int userID);
        void Add(Usuario usuario);
        void Delete(int usuarioID);
        void Update(Usuario user);
    }
}
