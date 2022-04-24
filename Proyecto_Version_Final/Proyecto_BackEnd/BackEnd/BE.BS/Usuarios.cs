using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;


namespace BE.BS
{
    public class Usuarios : ICRUD<data.Usuario>
    {

        private dal.Usuario _dal;
        public Usuarios(NDbContext dbContext)
        {
            _dal = new dal.Usuario(dbContext);
        }
        public void Delete(data.Usuario t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Usuario GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Usuario> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Usuario t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Usuario t)
        {
            _dal.Update(t);
        }
    }
}
