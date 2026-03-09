

namespace CodeTechAssignment.Services.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IOtpService> _mockOtpService;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockOtpService = new Mock<IOtpService>();
        _userService = new UserService(_mockUserRepository.Object, _mockOtpService.Object);
    }

    [Fact]
    public async Task RegisterNewCustomerAsync_WithValidOtp_ShouldRegisterUser()
    {
        // Arrange
        var req = new RegisterUserDto { MobileNumber = "1234567890", OtpCode = "1234", FullName = "Test User", Cnic = "1234567890123" };
        _mockUserRepository.Setup(x => x.GetUserByMobileAsync(req.MobileNumber)).ReturnsAsync((User)null);
        _mockOtpService.Setup(x => x.ValidateOtpAsync(req.MobileNumber, req.OtpCode)).ReturnsAsync(true);

        // Act
        var result = await _userService.RegisterNewCustomerAsync(req);

        // Assert
        result.Should().Be("New customer registered successfully.");
        _mockUserRepository.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Once);
        _mockUserRepository.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task RegisterNewCustomerAsync_WithInvalidOtp_ShouldThrowException()
    {
        // Arrange
        var req = new RegisterUserDto { MobileNumber = "1234567890", OtpCode = "9999", FullName = "Test User", Cnic = "1234567890123" };
        _mockUserRepository.Setup(x => x.GetUserByMobileAsync(req.MobileNumber)).ReturnsAsync((User)null);
        _mockOtpService.Setup(x => x.ValidateOtpAsync(req.MobileNumber, req.OtpCode)).ReturnsAsync(false); // Simulating bad OTP

        // Act
        Func<Task> act = async () => await _userService.RegisterNewCustomerAsync(req);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Invalid or expired OTP. Registration failed.");
        _mockUserRepository.Verify(x => x.AddUserAsync(It.IsAny<User>()), Times.Never); // db never touched
    }
}
