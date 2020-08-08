using System;
using Login.Domain.Commands;
using Login.Domain.Commands.Contracts;
using Login.Domain.Entities;
using Login.Domain.Handlers.Contracts;
using Login.Domain.Queries;
using Login.Domain.Respositories;

namespace Login.Domain.Handlers
{
    public class GetUserByUserNamePasswordHandler : IHandler<GetUserByUserNamePasswordQuery>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUserNamePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ICommandResult handle(GetUserByUserNamePasswordQuery query)
        {
            try
            {
                //fast fail validations
                query.Validate();

                //return invalid command
                if (query.Invalid) {
                    return new CommandResult(query.Notifications,"Invalid Command",false);
                }


                var user = _userRepository.FindUser(query.UserName, query.Password);
                            
                return new CommandResult(user,"Query made with sucess",true);

            } 
            catch(Exception ex)
            {
                return new CommandResult(ex,"Error on create a new user",false);

            }

        }
    }
}