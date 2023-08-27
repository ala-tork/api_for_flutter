using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using api_for_flutter.Models.UserModel;
using api_for_flutter.Data;

namespace CoolApi.Controllers

{
    [Route("[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly ApplicationDBContext _cxt;

        public UserController(ApplicationDBContext context)
        {
            _cxt = context;
        }

        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!Ashsnskajuh");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim("Password", user.password),
                    new Claim("firstname", user.firstname),
                    new Claim("lastname", user.lastname),
                    new Claim("phone", user.phone),
                    new Claim("country", user.country),
                    new Claim("address", user.address),
                    new Claim("id", user.Id.ToString()),
                    new Claim("active", user.active.ToString()),
                    new Claim("role", user.role.ToString()),
                    new Claim("refreshToken", user.RefreshToken),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpPost]
        [Route("refresh-token")]
        public IActionResult RefreshToken([FromQuery] string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest("Invalid refresh token");
            }

            var user = _cxt.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            if (user == null)
            {
                return BadRequest("Invalid refresh token");
            }
            user.RefreshToken = GenerateRefreshToken();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!Ashsnskajuh");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Email, user.email),
            new Claim("Password", user.password),
            new Claim("id", user.Id.ToString()),
            new Claim("active", user.active.ToString()),
            new Claim("role", user.role.ToString()),
            new Claim("refreshToken", user.RefreshToken),
        }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var newToken = tokenHandler.CreateToken(tokenDescriptor);
            //user.RefreshToken = GenerateRefreshToken();
            _cxt.SaveChanges();

            var newRefreshToken = user.RefreshToken; // Get the updated refresh token value

            return Ok(new
            {
                token = tokenHandler.WriteToken(newToken),
                refreshToken = newRefreshToken // Include the new refresh token in the response
            });
        }

        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private bool IsValidRefreshToken(string refreshToken)
        {
            var user = _cxt.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
            return user != null;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult CreateStudent(User user)
        {
            var existingUser = _cxt.Users.FirstOrDefault(u => u.email == user.email);
            if (existingUser != null)
            {
                return Conflict("User already exists.");
            }

            user.password = HashPassword(user.password);

            var refreshToken = GenerateRefreshToken();

            // Assign the refresh token to the user
            user.RefreshToken = refreshToken;
            _cxt.Users.Add(user);
            _cxt.SaveChanges();

            return Ok("User created successfully.");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult AuthenticateUser([FromBody] User user)
        {
            var storedUser = _cxt.Users.FirstOrDefault(u => u.email == user.email);

            if (storedUser == null)
            {
                return BadRequest("Invalid email or password");
            }

            var isPasswordValid = VerifyPassword(user.password, storedUser.password);

            if (!isPasswordValid)
            {
                return BadRequest("Invalid email or password");
            }

            var token = GenerateJwtToken(storedUser);

            return Ok(new { token });
        }

        [HttpPut]
        [Route("update-password")]
        [Authorize]
        public IActionResult UpdatePassword(string currentPassword, string newPassword)
        {
            // Get the user's email from the Claims
            var userEmailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (userEmailClaim == null)
            {
                return BadRequest("Invalid user.");
            }

            // Find the user in the database by their email
            var user = _cxt.Users.FirstOrDefault(u => u.email == userEmailClaim.Value);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Verify the current password
            var isCurrentPasswordValid = VerifyPassword(currentPassword, user.password);
            if (!isCurrentPasswordValid)
            {
                return BadRequest("Invalid current password.");
            }

            // Hash and update the new password
            user.password = HashPassword(newPassword);

            // Save changes to the database
            _cxt.SaveChanges();

            return Ok("Password updated successfully.");
        }

        [HttpPost]
        [Route("VerifyOTP")]
        [Authorize]
        public async Task<IActionResult> UpdateUserActiveStatus(int? id)
        {
            try
            {
                var user = await _cxt.Users.FirstOrDefaultAsync(u => u.Id == id);
                Console.WriteLine("user id " + id);
                if (user != null)
                {
                    user.active = 1;
                    await _cxt.SaveChangesAsync();

                    return Ok(true);
                }

                return NotFound("User not found.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating user active status: " + e.Message);
                return StatusCode(500, "An error occurred while updating the user's active status.");
            }
        }

        [HttpPost]
        [Route("search")]
        [Authorize]
        public IActionResult SearchUser(string search)
        {
            string query = $"SELECT * FROM Users WHERE firstname LIKE '%{search}%' OR email LIKE '%{search}%';";
            var searchResults = _cxt.Users.FromSqlRaw(query).ToList();

            // Return the search results
            return Ok(searchResults);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var existingUser = _cxt.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the properties of the existing user with the new values
            // Check if the properties are provided in the request and update accordingly
            if (!string.IsNullOrEmpty(updatedUser.firstname))
            {
                existingUser.firstname = updatedUser.firstname;
            }

            if (!string.IsNullOrEmpty(updatedUser.lastname))
            {
                existingUser.lastname = updatedUser.lastname;
            }

            // Do not update the email if it is not provided in the request
            // existingUser.email = updatedUser.email;

            if (!string.IsNullOrEmpty(updatedUser.phone))
            {
                existingUser.phone = updatedUser.phone;
            }

            if (!string.IsNullOrEmpty(updatedUser.address))
            {
                existingUser.address = updatedUser.address;
            }

            if (!string.IsNullOrEmpty(updatedUser.country))
            {
                existingUser.country = updatedUser.country;
            }

            // Save changes to the database
            _cxt.SaveChanges();

            return Ok(existingUser);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _cxt.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the error and return an error response
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user.");
            }
        }


        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            var user = _cxt.Users.FirstOrDefault(u => u.email == email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Generate a random password
            string newPassword = GenerateRandomPassword(10);
            user.password = HashPassword(newPassword);

            // Save changes to the database
            _cxt.SaveChanges();

            // Send the password reset email
            SendPasswordResetEmail(email, newPassword);
            return Ok("Password reset successful. Please check your email for the new password.");
        }

        private string HashPassword(string password)
        {
            // Generate a salt for hashing
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password using BCrypt with the generated salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        private void SendPasswordResetEmail(string userEmail, string newPassword)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Ecommerce App", "scongresses@gmail.com"));
            message.To.Add(new MailboxAddress(userEmail, userEmail));
            message.Subject = "Password Reset";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Your new password is: {newPassword}";

            message.Body = bodyBuilder.ToMessageBody();


            using (var client = new SmtpClient())
            {
                var uri = new Uri("smtps://smtp.gmail.com:465");
                var cancellationToken = new CancellationToken();

                client.Connect(uri, cancellationToken);

                var credentials = new NetworkCredential("scongresses@gmail.com", "rmnhfzorebtozejl");


                client.Authenticate("scongresses@gmail.com", "rmnhfzorebtozejl");

                client.Send(message);
                client.Disconnect(true);

            }
        }

        private string GenerateRandomPassword(int length)
        {
            // Generate a random password of the specified length
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }




        [HttpPost]
        [Route("verify-token")]
        public IActionResult VerifyToken([FromBody] TokenVerificationRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!Ashsnskajuh");

            try
            {
                // Validate the token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero // No tolerance for expired tokens
                };

                var claimsPrincipal = tokenHandler.ValidateToken(request.Token, tokenValidationParameters, out SecurityToken validatedToken);

                // Token is valid, extract user data from claims if needed
                // ...

                return Ok("Token is valid.");
            }
            catch (SecurityTokenException)
            {
                return BadRequest("Invalid token.");
            }
        }



        //[HttpPost]
        //[Route("verify-token")]
        //public IActionResult VerifyToken([FromBody] TokenVerificationRequest request)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("ABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!AshsnskajuhABCDeujujsik@!!Ashsnskajuh");

        //    try
        //    {
        //        // Validate the token
        //        var tokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            ClockSkew = TimeSpan.Zero // No tolerance for expired tokens
        //        };

        //        var claimsPrincipal = tokenHandler.ValidateToken(request.Token, tokenValidationParameters, out SecurityToken validatedToken);

        //        // Token is valid, extract user data from claims
        //        var userIdClaim = claimsPrincipal.FindFirst("id");
        //        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        //        {
        //            return BadRequest("Invalid token.");
        //        }

        //        // Find the user in the database by ID
        //        var user = _cxt.Users.FirstOrDefault(u => u.Id == userId);
        //        if (user == null)
        //        {
        //            return NotFound("User not found.");
        //        }

        //        // Check if the refresh token is valid
        //        if (!IsValidRefreshToken(request.RefreshToken))
        //        {
        //            return BadRequest("Invalid refresh token.");
        //        }

        //        // Generate a new access token
        //        var newAccessToken = GenerateJwtToken(user);

        //        // Update and save the new refresh token
        //        user.RefreshToken = GenerateRefreshToken();
        //        _cxt.SaveChanges();

        //        return Ok(new
        //        {
        //            User = user,
        //            AccessToken = newAccessToken,
        //            RefreshToken = user.RefreshToken
        //        });
        //    }
        //    catch (SecurityTokenException)
        //    {
        //        return BadRequest("Invalid token.");
        //    }
        //}


    }
}