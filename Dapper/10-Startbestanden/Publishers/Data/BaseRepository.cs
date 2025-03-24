namespace Publishers.Data;

public abstract class BaseRepository
{
    protected string ConnectionString { get; }

    public BaseRepository()
    {
        string computerName = Environment.MachineName;

        if (computerName == "LAPTOP-RFQLL7A5")
        {
            ConnectionString = DatabaseConnection.Connectionstring("PublishersConnectionString");

        }
        else if (computerName == "Sels")
        {
            ConnectionString = DatabaseConnection.Connectionstring("PublishersConnectionStringDocker");
        }
    }
}