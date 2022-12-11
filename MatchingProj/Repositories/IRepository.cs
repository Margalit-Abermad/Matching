using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public interface IRepository<T>
{
    List<T> GetAll();
    T GetById(int Id);
    void Create(T ObjToCreate);
    void Update(T ObjToUpdate);
    void Delete(int Id);
}
