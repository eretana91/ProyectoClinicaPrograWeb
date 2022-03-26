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
    public class CitasProgramadas : ICRUD<data.CitasProgramadas>
    {
        private dal.CitasProgramadas _dal;
        public CitasProgramadas(NDbContext dbContext)
        {
            _dal = new dal.CitasProgramadas(dbContext);
        }
        public void Delete(data.CitasProgramadas t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.CitasProgramadas> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.CitasProgramadas>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.CitasProgramadas GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.CitasProgramadas> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.CitasProgramadas t)
        {
            _dal.Insert(t);
        }

        public void Update(data.CitasProgramadas t)
        {
            _dal.Update(t);
        }
    }
}
