using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryPersona : IRepository<data.Persona>
    {
        Task<IEnumerable<data.Persona>> GetAllAsync();
        Task<data.Persona> GetOneByIdAsync(int id);
    }
}
