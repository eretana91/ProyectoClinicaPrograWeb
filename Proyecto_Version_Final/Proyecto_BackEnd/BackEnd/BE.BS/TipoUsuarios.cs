﻿using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class TipoUsuarios : ICRUD<data.TipoUsuario>
    {

        private dal.TipoUsuario _dal;
        public TipoUsuarios(NDbContext dbContext)
        {
            _dal = new dal.TipoUsuario(dbContext);
        }
        public void Delete(data.TipoUsuario t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.TipoUsuario> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.TipoUsuario>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.TipoUsuario GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.TipoUsuario> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.TipoUsuario t)
        {
            _dal.Insert(t);
        }

        public void Update(data.TipoUsuario t)
        {
            _dal.Update(t);
        }
    }
}
