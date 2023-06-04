using FakeItEasy;
using System.Linq.Expressions;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId
            };

            A.CallTo(() => userRepositoryMock.GetByIdAsync(userId, cancellationSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancellationSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("Ayşe", "Akışık", 23, string.Empty, cancellationSource.Token));
            await Assert.ThrowsAsync<ArgumentException>(() => userService.AddAsync("Ayşe", "Akışık", 23, null, cancellationSource.Token));
        }

        [Fact]
        public async Task AddAsync_ShouldReturnFalse_WhenUserIdIsEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = Guid.NewGuid()
            };

            A.CallTo(() => userRepositoryMock.AddAsync(expectedUser, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.AddAsync("Ayşe", "Akışık", 23, "ayseakisik16@gmail.com", cancellationSource.Token);

            Assert.False(user == Guid.Empty);
            Assert.False(user == (Guid?)null);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            A.CallTo(() => userRepositoryMock.DeleteAsync(A<Expression<Func<User, bool>>>.Ignored, cancellationSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.DeleteAsync(Guid.NewGuid(), cancellationSource.Token);

            Assert.True(user);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(() => userService.DeleteAsync(Guid.Empty, cancellationSource.Token));
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            var expectedUser = new User()
            {
                Id = Guid.Empty
            };

            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(expectedUser, cancellationSource.Token));
        }

        [Fact] 
        public async Task UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            var emailIsEmptyUser = new User() { Id = Guid.NewGuid(), Email = string.Empty };
            var emailIsNullUser = new User() { Id = Guid.NewGuid(), Email = null };

            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(emailIsEmptyUser, cancellationSource.Token));
            await Assert.ThrowsAsync<ArgumentException>(() => userService.UpdateAsync(emailIsNullUser, cancellationSource.Token));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            List<User> userList = new List<User>()
            {
                new User() { Id = Guid.NewGuid() },
                new User() { Id = Guid.NewGuid() }
            };

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancellationSource.Token))
                .Returns(Task.FromResult(userList));

            IUserService userService = new UserManager(userRepositoryMock);

            var users = await userService.GetAllAsync(cancellationSource.Token);

            Assert.True(users.Count >= 2);
        }
    }
}
