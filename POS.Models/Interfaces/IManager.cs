using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Interfaces
{
    public interface IManager<T> where T : class
    {
        bool Add(T entity);

        bool Add(ICollection<T> entities);

        bool Remove(long id);

        bool Update(T entity);

        bool Update(ICollection<T> entities);

        T GetById(long id);

        ICollection<T> GetAll();
    }
}
