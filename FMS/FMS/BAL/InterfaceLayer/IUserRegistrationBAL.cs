using System;
using System.Threading.Tasks;

namespace FMS
{
	#region for user registration Interface
	public interface IUserRegistrationBAL : IDisposable
	{
		Task<UserRegistration> UserRegistration(UserRegistrationRequest request);
	}
	#endregion
}
