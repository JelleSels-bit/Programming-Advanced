namespace Publishers.Data;

public abstract class BaseRepository
{
    protected string ConnectionString { get; }

    public BaseRepository()
    {

        ConnectionString = DatabaseConnection.Connectionstring("PublishersConnectionString");
        //string computerName = Environment.MachineName;

        //if (computerName == "LAPTOP-RFQLL7A5")
        //{
            

        //}
        //else if (computerName == "Sels")
        //{
        //    ConnectionString = DatabaseConnection.Connectionstring("PublishersConnectionStringDocker");
        //}
    }
}