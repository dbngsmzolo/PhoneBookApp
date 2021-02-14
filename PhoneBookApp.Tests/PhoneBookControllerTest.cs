using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using PhoneBookApp.Services.Interfaces;

namespace PhoneBookApp.Tests
{
    [TestClass]
    public class PhoneBookControllerTest
    {
        Mock<IPhoneBookService> _service;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<IPhoneBookService>();
        }
        
    }
}
