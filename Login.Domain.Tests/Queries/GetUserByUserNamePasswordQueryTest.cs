using Login.Domain.Tests.Mokcs.Commands;
using Login.Domain.Tests.Mokcs.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Login.Domain.Tests
{
    [TestClass]
    public class GetUserByUserNamePasswordQueryTest
    {
        [TestMethod]
        public void ShouldReturnSucessWithValidQueryToUser()
        {
            var query = GetUserByUserNamePasswordQueryMock.validCommand();
            query.Validate();

            Assert.AreEqual(true, query.Valid);
        }

        [TestMethod]
        public void ShouldReturnFailWithInvalidQueryToUser()
        {
            var query = GetUserByUserNamePasswordQueryMock.invalidCommand();
            query.Validate();

            Assert.AreEqual(false, query.Invalid);
        }
    }
}
