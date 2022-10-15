namespace JobsityApi.Utils.CustomExceptions;

public class InvalidLoginOrPasswordException : CustomException
{
    public InvalidLoginOrPasswordException() : base("Login or password invalid.")
    {

    }
}
