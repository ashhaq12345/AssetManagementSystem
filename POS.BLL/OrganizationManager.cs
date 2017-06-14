using POS.DAL;
using POS.Models;
using POS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL
{
    public class OrganizationManager: IOrganizationManager
    {
        IOrganizationRepository _repository;

        public OrganizationManager()
        {
            _repository = new OrganizationRepository();
        }

        public OrganizationManager(IOrganizationRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Organization entity)
        {
            return _repository.Add(entity);
        }

        public bool Add(ICollection<Organization> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Organization> GetAll()
        {
            return _repository.GetAll();
        }

        public Organization GetById(long id)
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

        public bool Update(Organization entity)
        {
            return _repository.Update(entity);
        }

        public bool Update(ICollection<Organization> entities)
        {
            throw new NotImplementedException();
        }
    }
}
