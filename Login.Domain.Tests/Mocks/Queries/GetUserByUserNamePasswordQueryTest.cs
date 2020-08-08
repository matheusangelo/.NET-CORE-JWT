using Login.Domain.Queries;

namespace Login.Domain.Tests.Mokcs.Queries
{
    public static class GetUserByUserNamePasswordQueryMock
    {
        public static GetUserByUserNamePasswordQuery validCommand()
        {
            return new GetUserByUserNamePasswordQuery("matheus.angelo","234123");
        }

        public static GetUserByUserNamePasswordQuery invalidCommand()
        {
            return new GetUserByUserNamePasswordQuery("", "");
        }
    }
}