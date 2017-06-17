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
    public class AssetLocationManager: IAssetLocationManager
    {
        IAssetLocationRepository _repository;

        public AssetLocationManager()
        {
            _repository = new AssetLocationRepository();
        }

        public AssetLocationManager(IAssetLocationRepository repository)
        {
            _repository = repository;
        }

        public bool Add(AssetLocation entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<AssetLocation> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<AssetLocation> GetAll()
        {
            return _repository.GetAll();
        }

        public AssetLocation GetById(long id)
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

        public bool Update(AssetLocation entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<AssetLocation> entities)
        {
            throw new NotImplementedException();
        }

        public List<Branch> GetBranchCategory()
        {
            return _repository.GetBranchCategory();
        }

        public bool IsShortNameUnique(string shortName)
        {
            return _repository.IsShortNameUnique(shortName);
        }
    }
}
