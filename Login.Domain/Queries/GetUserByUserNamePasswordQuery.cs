using Flunt.Notifications;
using Flunt.Validations;
using Login.Domain.Queries.Contracts;

namespace Login.Domain.Queries
{
    public class GetUserByUserNamePasswordQuery : Notifiable, IQuery
    {
        public GetUserByUserNamePasswordQuery()
        {
            
        }
        public GetUserByUserNamePasswordQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName {get;set;}
        public string Password {get;set;}

        public void Validate()
        {
            AddNotifications(new Contract()
             .IsNotNull(UserName, "UserName", "UserName is not null")
             .IsNotNull(Password, "Password", "Password is not null"));

        }
    }
}