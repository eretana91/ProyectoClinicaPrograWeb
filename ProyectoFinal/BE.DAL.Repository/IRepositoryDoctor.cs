using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    internal interface IRepositoryDoctor : IRepository<data.Doctor>
    {
        Task<IEnumerable<data.Doctor>> GetAllAsync();
        Task<data.Doctor> GetOneByIdAsync(int id);
    }
}
