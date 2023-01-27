namespace Jotform;

public partial class JotformClient
{
    public Task PostUserRegisterAsync(string username, string password, string email, CancellationToken cancellationToken = default) 
        => throw new NotSupportedException();
}