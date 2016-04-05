using System.Collections.Generic;
using SomeBL.Entities;

namespace SomeBL.Interface
{
    public interface IRepository
    {
        bool Create(UserEntity entity);
        UserEntity Read(int id);
        bool Update(UserEntity entity);
        bool Delete(UserEntity entity);
        IEnumerable<UserEntity> GetAll();
    }
}