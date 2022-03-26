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
    public class Citas : ICRUD<data.Citas>
    {

        private dal.Citas _dal;
        public Citas(NDbContext dbContext)
        {
            _dal = new dal.Citas(dbContext);
        }
        public void Delete(data.Citas t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Citas> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Citas>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Citas GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Citas> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Citas t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Citas t)
        {
            _dal.Update(t);
        }
    }
}
