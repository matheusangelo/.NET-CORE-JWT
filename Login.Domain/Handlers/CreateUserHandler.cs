using System;
using System.Threading.Tasks;
using Login.Domain.Commands;
using Login.Domain.Commands.Contracts;
using Login.Domain.Entities;
using Login.Domain.Handlers.Contracts;
using Login.Domain.Respositories;

namespace Login.Domain.Handlers
{
    public class CreateUserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ICommandResult handle(CreateUserCommand command)
        {
            try
            {
                //fast fail validations
                command.Validate();

                //Validate e-mail

                if (_userRepository.EmailAlreadyExists(command.Email)){
                    return new CommandResult(command.Notifications,"Email already exists, please send another email",false);
                }
                //return invalid command
                if (command.Invalid) {
                    return new CommandResult(command.Notifications,"Invalid Command",false);
                }

                var user = new User();

                user.Age = command.Age;
                user.Email = command.Email;
                user.FirstName = command.FirstName;
                user.Roule = command.Roule;
                user.Password = command.Password;
                user.UserName = command.UserName;
                user.Roule = command.Roule;
                user.SurName = command.SurName;

                _userRepository.AddUser(user);
            
                return new CommandResult(command,"User Created",true);

            } 
            catch(Exception ex)
            {
                return new CommandResult(ex,"Error on create a new user",false);

            }

        }
    }
}