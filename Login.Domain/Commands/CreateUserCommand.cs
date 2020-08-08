using Flunt.Notifications;
using Flunt.Validations;
using Login.Domain.Commands.Contracts;
using Login.Domain.Enuns;

namespace Login.Domain.Commands
{
    public class CreateUserCommand : Notifiable, ICommand
    {

        public CreateUserCommand()
        {
            
        }

        public CreateUserCommand(string firstName, string surName, string userName, string password, int age, string email, EnunUserType roule)
        {
            FirstName = firstName;
            SurName = surName;
            UserName = userName;
            Password = password;
            Age = age;
            Email = email;
            Roule = EnunUserType.Common;
        }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public EnunUserType Roule { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
             .HasMaxLen(FirstName, 40, "FirstName", "Name should have no more than 40 chars")
             .HasMinLen(SurName, 3, "SurName", "SurName should have at least 3 chars")
             .IsNotNull(Age, "Age", "Age is not null")
             .HasMaxLen(UserName, 15, "UserName", "UserName should have no more than 15 chars")
             .HasMaxLen(Password, 8, "Password", "Password should have no more than 8 chars")
             .IsEmail(Email,"Email", "Email invalid")
             );
        }
    }
}