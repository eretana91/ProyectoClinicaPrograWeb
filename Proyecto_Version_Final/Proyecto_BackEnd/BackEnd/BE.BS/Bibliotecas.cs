using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;
using BE.DAL.DO.Objects;

namespace BE.BS
{
    public class Bibliotecas : ICRUD<data.Biblioteca>
    {
        private dal.Biblioteca _dal;
        public Bibliotecas(NDbContext dbContext)
        {
            _dal = new dal.Biblioteca(dbContext);
        }
        public void Delete(Biblioteca t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<Biblioteca> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<Biblioteca>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Biblioteca GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<Biblioteca> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Biblioteca t)
        {
            _dal.Insert(t);
        }

        public void Update(Biblioteca t)
        {
            _dal.Update(t);
        }
    }
}
