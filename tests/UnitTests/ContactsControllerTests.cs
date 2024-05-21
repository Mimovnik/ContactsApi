
using Contacts.Api.Controllers;
using Contacts.Application.Contacts.Queries;
using Contacts.Application.Interfaces.Persistence;
using Contacts.Contracts;
using Contacts.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests;

public class ContactsControllerTests
{
    [Fact]
    public void GetAllContacts_WhenRepositoryIsEmpty_ShouldRespondOkAndReturnEmptyList()
    {
        // Arrange
        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetAllContactsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Contact>());

        var mapper = new Mock<IMapper>();
        mapper.Setup(m => m.Map<IEnumerable<ContactResponse>>(It.IsAny<IEnumerable<Contact>>()))
            .Returns(new List<ContactResponse>());

        var controller = new ContactsController(mapper.Object, mediator.Object);

        // Act
        var result = controller.GetAllContacts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsAssignableFrom<IEnumerable<ContactResponse>>(okResult.Value);
        Assert.Empty(response);
    }

    [Fact]
    public void GetAllContacts_WhenSomeContactsInRepository_ShouldRespondOkAndReturnListOfContacts()
    {
        // Arrange
        var contacts = new List<Contact>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                Password = "password",
                Category = "private",
                Subcategory = "friend",
                PhoneNumber = "123456789",
                BirthDate = "2000-01-01",
            },
            new()
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Davis",
                Email = "jane.davis@email.com",
                Password = "password",
                Category = "private",
                Subcategory = "friend",
                PhoneNumber = "123456789",
                BirthDate = "2000-01-01",
            },
        };

        var mediator = new Mock<IMediator>();
        mediator.Setup(m => m.Send(It.IsAny<GetAllContactsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(contacts);

        var mapper = new Mock<IMapper>();
        mapper.Setup(m => m.Map<IEnumerable<ContactResponse>>(It.IsAny<IEnumerable<Contact>>()))
            .Returns(contacts.Select(c => new ContactResponse(
                c.Id,
                c.FirstName,
                c.LastName,
                c.Email,
                c.Password,
                c.Category,
                c.Subcategory,
                c.PhoneNumber,
                c.BirthDate)));

        var controller = new ContactsController(mapper.Object, mediator.Object);

        // Act
        var result = controller.GetAllContacts();

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsAssignableFrom<IEnumerable<ContactResponse>>(okResult.Value);
        Assert.Equal(contacts.Count, response.Count());
    }
}
