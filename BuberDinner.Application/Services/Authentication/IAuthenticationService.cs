using BuberDinner.Application.Common.Errors;
using OneOf;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password);
}