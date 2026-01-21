namespace Persistence.Exceptions.Teams;

public partial class TeamNotFound
{
    public string Name { get; private set; }

    public TeamNotFound(string name)
    {
        Name = name;
    }

    public TeamNotFound(string name, string message)
        : base(message)
    {
        Name = name;
    }

    public TeamNotFound(string name, string message, Exception innerException)
        : base(message, innerException)
    {
        Name = name;
    }
}