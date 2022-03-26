using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryReporteCitas : IRepository<data.ReporteCitas>
    {
        Task<IEnumerable<data.ReporteCitas>> GetAllAsync();
        Task<data.ReporteCitas> GetOneByIdAsync(int id);
    }
}
