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
    public class Inventarios : ICRUD<data.Inventarios>
    {

        private dal.Inventarios _dal;
        public Inventarios(NDbContext dbContext)
        {
            _dal = new dal.Inventarios(dbContext);
        }
        public void Delete(data.Inventarios t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Inventarios> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Inventarios>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Inventarios GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Inventarios> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Inventarios t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Inventarios t)
        {
            _dal.Update(t);
        }
    }
}
