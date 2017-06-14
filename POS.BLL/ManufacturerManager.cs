using POS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models;
using POS.DAL;

namespace POS.BLL
{
    public class ManufacturerManager : IManufacturerManager
    {
        private IManufacturerRepository _repository;

        public ManufacturerManager()
        {
            _repository = new ManufacturerRepository();
        }

        public ManufacturerManager(IManufacturerRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Manufacturer entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<Manufacturer> entities)
        {
            return _repository.Add(entities);
        }

        public ICollection<Manufacturer> GetAll()
        {
            return _repository.GetAll();
        }

        public Manufacturer GetById(long id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(long id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }
            return _repository.Remove(entity);
        }

        public bool Update(Manufacturer entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<Manufacturer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
