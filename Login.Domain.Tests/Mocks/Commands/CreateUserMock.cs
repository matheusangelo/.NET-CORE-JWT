using Login.Domain.Commands;
using Login.Domain.Enuns;

namespace Login.Domain.Tests.Mokcs.Commands
{
    public static class CreateUserCommandMock
    {
        public static CreateUserCommand validCommand()
        {
            return new CreateUserCommand("Matheus", "Angelo", "matheus.angelo", "40540265", 10, "matheusangelo10@gmail.com", EnunUserType.Common);
        }

        public static CreateUserCommand invalidCommand()
        {
            return new CreateUserCommand("", "", "", "", 10, "matheusangelogmail.com", EnunUserType.Master);
        }
    }
}