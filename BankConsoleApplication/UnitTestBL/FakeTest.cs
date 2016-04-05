using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeBL;
using SomeBL.Entities;
using SomeBL.Interface;

namespace UnitTestBL
{
    [TestClass]
    public class FakeTest
    {
        private class FakeRepository : IRepository
        {
            private List<UserEntity> users = new List<UserEntity>(); 

            public bool Create(UserEntity entity)
            {
                this.users.Add(entity);

                return this.users.Contains(entity);
            }

            public UserEntity Read(int id)
            {
                return this.users.FirstOrDefault(user => user.Id == id);
            }

            public bool Update(UserEntity entity)
            {
                var userEl = users.FirstOrDefault(user => user.Id == entity.Id);
                userEl.Password = entity.Password;
                userEl.UserName = entity.UserName;

                return this.users.Contains(entity);
            }

            public bool Delete(UserEntity entity)
            {
                users.Remove(entity);

                return !users.Contains(entity);
            }

            public IEnumerable<UserEntity> GetAll()
            {
                return users;
            }
        }

        private class StubUser
        {
            public UserEntity PrepareUser()
            {
                return new UserEntity { Id = 1, Password = "SuperPass", UserName = "John" };
            }
        }

        //[TestMethod]
        public void Fake_AddUser_True()
        {
            var userRepository = new FakeRepository();
            CreateUserService sut = new CreateUserService(userRepository);
            var stubUser = new StubUser();
            var testData = stubUser.PrepareUser();

            sut.CreateUser(testData);

            Assert.AreEqual(testData, userRepository.Read(testData.Id));
        }
        

    }
}