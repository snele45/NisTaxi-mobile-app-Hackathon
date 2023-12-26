namespace WebApplication1.Authentication
{
	public interface IAuthenticationService
	{
		string Authenticate(string phoneNumber, string taxiCardNumber);
	}
}