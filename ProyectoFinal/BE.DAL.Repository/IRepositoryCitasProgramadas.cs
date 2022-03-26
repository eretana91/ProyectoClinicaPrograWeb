using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryCitasProgramadas : IRepository<data.CitasProgramadas>
    {
        Task<IEnumerable<data.CitasProgramadas>> GetAllAsync();
        Task<data.CitasProgramadas> GetOneByIdAsync(int id);
    }
}
