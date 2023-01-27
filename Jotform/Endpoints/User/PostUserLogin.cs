namespace Jotform;

public partial class JotformClient
{
    public Task PostUserLoginAsync(string username, string password, CancellationToken cancellationToken = default) 
        => throw new NotSupportedException();
}