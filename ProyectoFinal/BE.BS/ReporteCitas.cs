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
    public class ReporteCitas : ICRUD<data.ReporteCitas>
    {
        private dal.ReporteCitas _dal;
        public ReporteCitas(NDbContext dbContext)
        {
            _dal = new dal.ReporteCitas(dbContext);
        }
        public void Delete(data.ReporteCitas t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.ReporteCitas> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.ReporteCitas>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.ReporteCitas GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.ReporteCitas> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.ReporteCitas t)
        {
            _dal.Insert(t);
        }

        public void Update(data.ReporteCitas t)
        {
            _dal.Update(t);
        }
    }
}
