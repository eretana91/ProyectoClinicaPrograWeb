using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using BE.DAL.EF;
using BE.DAL.Repository;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace BE.DAL
{
    public class ReporteCitas : ICRUD<data.ReporteCitas>
    {
        private RepositoryReporteCitas repo;
        public ReporteCitas(NDbContext dbContext)
        {
            repo = new RepositoryReporteCitas(dbContext);
        }
        public void Delete(data.ReporteCitas t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.ReporteCitas> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.ReporteCitas>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.ReporteCitas GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.ReporteCitas> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.ReporteCitas t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.ReporteCitas t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
