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
    public class CategoryManager: ICategoryManager
    {
        ICategoryRepository _repository;

        public CategoryManager()
        {
            _repository = new CategoryRepository();
        }

        public CategoryManager(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Category entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<Category> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetById(long id)
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

        public bool Update(Category entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<Category> entities)
        {
            throw new NotImplementedException();
        }

        public List<GeneralCategory> GetGeneralCategory()
        {
            return _repository.GetGeneralCategory();
        }

        public bool IsShortNameUnique(string shortName)
        {
            return _repository.IsShortNameUnique(shortName);
        }
    }
}
