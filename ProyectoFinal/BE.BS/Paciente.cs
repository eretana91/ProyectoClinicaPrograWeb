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
    public class Paciente : ICRUD<data.Paciente>
    {
        private dal.Paciente _dal;
        public Paciente(NDbContext dbContext)
        {
            _dal = new dal.Paciente(dbContext);
        }
        public void Delete(data.Paciente t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Paciente> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Paciente>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Paciente GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Paciente> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Paciente t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Paciente t)
        {
            _dal.Update(t);
        }
    }
}
