using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Domain.Entities;
using Login.Domain.Infra.Contexts;
using Login.Domain.Respositories;
using Microsoft.EntityFrameworkCore;

namespace Login.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly LoginSampleContext _loginSampleContext;

        public UserRepository(LoginSampleContext loginSampleContext)
        {
            _loginSampleContext = loginSampleContext;
        }

        public void AddUser(User user)
        {
            _loginSampleContext.users.Add(user);
            _loginSampleContext.SaveChanges();
        }

        public void DeleteUsers(User user)
        {
            _loginSampleContext.users.Remove(user);
            _loginSampleContext.SaveChanges();
        }

        public bool EmailAlreadyExists(string Email)
        {
            var exists = false;
            
            var user = _loginSampleContext.users
                                          .AsNoTracking()
                                          .Where( u => u.Email == Email);

            if (user.Count() > 0){
                exists = true;
            }

            return exists;
        }

        public User FindUser(string UserName, string Password)
        {
            return _loginSampleContext.users.Where( u=> u.UserName == UserName && u.Password == Password )
                                            .FirstOrDefault();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _loginSampleContext.users.ToListAsync();
        }

        public User GetUserById(Guid Id)
        {
            return _loginSampleContext.users.Where( u=> u.Id == Id).FirstOrDefault();
        }

        public User UpdateUser(User user)
        {
            _loginSampleContext.Entry(user).State = EntityState.Modified;
            
            _loginSampleContext.SaveChanges();
            
            return user;
        }
    }
}