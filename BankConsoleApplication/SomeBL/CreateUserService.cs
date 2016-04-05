using SomeBL.Entities;
using SomeBL.Interface;

namespace SomeBL
{
    public class CreateUserService
    {
        private readonly IRepository _repository;

        public CreateUserService(IRepository repository)
        {
            this._repository = repository;
        }

        public bool CreateUser(UserEntity entity)
        {
            return _repository.Create(entity);
        }
    }
}