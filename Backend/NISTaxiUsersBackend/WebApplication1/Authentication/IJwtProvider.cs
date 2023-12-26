using WebApplication1.Entities;

namespace WebApplication1.Authentication
{
	public interface IJwtProvider
	{
		string Generate(Driver user);
	}
}