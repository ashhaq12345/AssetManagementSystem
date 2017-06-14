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
    public class ModelManager: IModelManager
    {
        private IModelRepository _repository;

        public ModelManager()
        {
            _repository = new ModelRepository();
        }

        public ModelManager(IModelRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Model entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<Model> entities)
        {
            return _repository.Add(entities);
        }

        public ICollection<Model> GetAll()
        {
            return _repository.GetAll();
        }

        public Model GetById(long id)
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

        public bool Update(Model entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<Model> entities)
        {
            throw new NotImplementedException();
        }
    }
}
