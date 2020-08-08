using Login.Domain.Tests.Mokcs.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Login.Domain.Tests
{
    [TestClass]
    public class CreateUserCommandTest
    {
        [TestMethod]
        public void ShouldReturnSucessWithValidCommandToCreateUser()
        {
            var command = CreateUserCommandMock.validCommand();
            command.Validate();

            Assert.AreEqual(true, command.Valid);
        }

        [TestMethod]
        public void ShouldReturnFailWithInvalidCommandToCreateUser()
        {
            var command = CreateUserCommandMock.invalidCommand();
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }
}
