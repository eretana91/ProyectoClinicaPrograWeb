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
    public class Events : ICRUD<data.Events>
    {

        private dal.Events _dal;
        public Events(NDbContext dbContext)
        {
            _dal = new dal.Events(dbContext);
        }
        public void Delete(data.Events t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Events> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Events>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Events GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Events> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Events t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Events t)
        {
            _dal.Update(t);
        }
    }
}
