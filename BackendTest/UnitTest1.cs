using AutoMapper;
using Backend.Controllers;
using Backend.Models.DTO;
using Backend.Repositories;
using Moq;

namespace BackendTest
{
    public class UnitTest1
    {
        private static ContactRepository _contactRepository;
        private static IMapper mapper;

        ContactContoller ContactContollerObj = new ContactContoller(_contactRepository, mapper);

        [Fact]
        public void GetAllAsync_Test()
        {
            // Arrange
            int id = 1;

            // Act
            var result = ContactContollerObj.GetContactAsync(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateContact_Test()
        {
            // Arrange
            var CreateContactDtoObj = new Mock<CreateContactDto>();

            // Act
            var result = ContactContollerObj.CreateContact(CreateContactDtoObj.Object);

            // Assert
            Assert.NotNull(result);
        }
    }
}