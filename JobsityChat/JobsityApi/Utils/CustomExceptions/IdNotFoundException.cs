namespace JobsityApi.Utils.CustomExceptions;

public class IdNotFoundException : CustomException
{
    public IdNotFoundException() : base("The passed id was not found.")
    {
    }
}
