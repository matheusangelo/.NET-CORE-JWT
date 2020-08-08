using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Domain.Entities;

namespace Login.Domain.Respositories
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        User GetUserById(Guid Id);
        void DeleteUsers(User user);
        void AddUser(User user);
        User UpdateUser(User user);
        bool EmailAlreadyExists(string Email);
        User FindUser(string UserName, string Password);
    }
}