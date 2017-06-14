using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Interfaces
{
    public interface ICommonRepository<T>: IDisposable where T: class 
    {
        bool Add(T entity);

        bool Update(T entity);

        bool Remove(T entity);

        T GetById(long id);

        ICollection<T> GetAll();

        bool Add(ICollection<T> entities);

        bool Update(ICollection<T> entities);
    }
}
