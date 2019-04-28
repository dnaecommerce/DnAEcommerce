using Xunit;
using DnAStore.Models.ViewModels;

namespace XUnitTest_DnAStore
{
    public class UnitTests_LoginViewModel
    {
        // Login View Model Tests
        [Fact]
        public void CanSetLoginEmail()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.Email = "test@test.test";
            Assert.NotNull(lvm.Email);
        }
        
        [Fact]
        public void CanGetLoginEmail()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.Email = "test@test.test";
            Assert.Equal("test@test.test", lvm.Email);
        }

        [Fact]
        public void CanSetLoginPassword()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.Password = "testPassword123!";
            Assert.NotNull(lvm.Password);
        }
        
        [Fact]
        public void CanGetLoginPassword()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.Password = "testPassword123!";
            Assert.Equal("testPassword123!", lvm.Password);
        }
    }
}
