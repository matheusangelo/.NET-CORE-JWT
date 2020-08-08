using Login.Domain.Enuns;

namespace Login.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            
        }

        public User(string firstName, string surName, string password, string userName, int age, string email)
        {
            FirstName = firstName;
            SurName = surName;
            Password = password;
            UserName = userName;
            Age = age;
            Email = email;
            Roule = EnunUserType.Common;
        }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Password {get;set;}
        public string UserName {get;set;}
        public int Age { get; set; }
        public string Email { get; set; }
        public EnunUserType Roule { get; set; }

    }
}