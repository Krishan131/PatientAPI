namespace PatientAPI.Services
{
    public interface IAuthService
    {
        string? Login(LoginRequest request);
    }
}
