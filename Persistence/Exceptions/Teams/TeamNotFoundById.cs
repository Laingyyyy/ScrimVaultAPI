namespace Persistence.Exceptions.Teams;

public partial class TeamNotFound : Exception
{
    public int? TeamId { get; private set; }
    
    public TeamNotFound(int? teamId)
    {
        TeamId = teamId;
    }
    
    public TeamNotFound(int? teamId, string message)
        : base(message)
    {
        TeamId = teamId;
    }

    public TeamNotFound(int? teamId, string message, Exception inner)
        : base(message, inner)
    {
        TeamId = teamId;
    }
}