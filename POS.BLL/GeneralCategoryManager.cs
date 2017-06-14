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
    public class GeneralCategoryManager: IGeneralCategoryManager
    {
        IGeneralCategoryRepository _repository;

        public GeneralCategoryManager()
        {
            _repository = new GeneralCategoryRepository();
        }

        public GeneralCategoryManager(IGeneralCategoryRepository repository)
        {
            _repository = repository;
        }

        public bool Add(GeneralCategory entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<GeneralCategory> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<GeneralCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public GeneralCategory GetById(long id)
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

        public bool Update(GeneralCategory entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<GeneralCategory> entities)
        {
            throw new NotImplementedException();
        }
    }
}
