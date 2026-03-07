using CodeTechAssignment.Application.DTOs;
using CodeTechAssignment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeTechAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _otpService;

        public OtpController(IOtpService otpService)
        {
            _otpService = otpService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto request)
        {
            var otp = await _otpService.GenerateAndSendOtpAsync(request.MobileNumber);
            // Returning OTP in response just for assignment testing purposes
            return Ok(new { message = "OTP Sent Successfully", mockOtp = otp }); 
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyDto request)
        {
            var isValid = await _otpService.ValidateOtpAsync(request.MobileNumber, request.OtpCode);
            if (!isValid)
                return BadRequest(new { message = "Invalid or expired OTP." });

            return Ok(new { message = "OTP Verified Successfully." });
        }
    }
}
