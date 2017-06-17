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
    public class BranchManager : IBranchManager
    {

        IBranchRepository _repository;

        public BranchManager()
        {
            _repository = new BranchRepository();
        }

        public BranchManager(IBranchRepository repository)
        {
            _repository = repository;
        }

        public bool Add(Branch entity)
        {
            if(_repository.IsShortNameUnique(entity))
            {
                return _repository.Add(entity);
            }
            throw new Exception("ShortName is Not Unique!");
        }

        public bool Add(ICollection<Branch> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Branch> GetAll()
        {
            return _repository.GetAll();
        }

        public Branch GetById(long id)
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

        public bool Update(Branch entity)
        {
            if (_repository.IsShortNameUnique(entity))
            {
                return _repository.Update(entity);
            }
            throw new Exception("ShortName is Not Unique!");
        }

        public bool Update(ICollection<Branch> entities)
        {
            throw new NotImplementedException();
        }

        public List<Organization> GetOrganizationCategories()
        {
            return _repository.GetOrganizationCategories();
        }

        public bool IsShortNameUnique(Branch branch)
        {
            return _repository.IsShortNameUnique(branch);
        }

        public ICollection<Branch> GetBranchByOrganization(long organizationId)
        {
            var branches = _repository.GetAll().AsQueryable().Where(c => c.OrganizationId == organizationId);
            return branches.ToList();
        }
    }
}
