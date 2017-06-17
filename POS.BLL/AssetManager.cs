using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;
using POS.Models.Interfaces;

namespace POS.BLL
{
    public class AssetManager: IAssetManager
    {
        IAssetRepository _repository;

        public AssetManager()
        {
            _repository = new AssetRepository();
        }

        public AssetManager(IAssetRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Asset entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<Asset> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Asset> GetAll()
        {
            return _repository.GetAll();
        }

        public Asset GetById(long id)
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

        public bool Update(Asset entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<Asset> entities)
        {
            throw new NotImplementedException();
        }


    }
}
