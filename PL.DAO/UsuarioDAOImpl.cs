using System;
using System.Collections.Generic;
using System.Text;
using PL.Model.POCO;
using PL.Model;
using System.Linq;
using System.Runtime.InteropServices;

namespace PL.DAO
{
    public class UsuarioDAOImpl : IUsuarioDAO
    {
        EstacionamentoContext context;

        public UsuarioDAOImpl()
        {
            context = new EstacionamentoContext();
        }
        public void Add(Usuario usuario)
        {
            context.Users.Add(usuario);
            context.SaveChanges();
        }

        public void Delete(int usuarioID)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Boolean validaUser(int userID)
        {
           if(GetAUsuarioByID(userID).nome.Equals("Not Found"))
            {
                return false;
            }
            return true;
        }



        public Usuario GetAUsuarioByID(int userID)
        {
           
                Usuario u;

                var lista = getUsuarios();
                foreach (Usuario user in lista)
                {
                    if (user.UsuarioID == userID)
                    {

                        u = user;

                        return u;
                    }

                }
            u = new Usuario();
            u.nome = "Not Found";
            return u;
        }

        public IEnumerable<Usuario> getUsuarios()
        {
            var usuarios = context.Users.ToList();
            return usuarios;
        }

        public void Update(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
