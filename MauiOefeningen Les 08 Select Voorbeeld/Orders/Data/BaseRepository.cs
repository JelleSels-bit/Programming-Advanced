﻿namespace Orders;

public abstract class BaseRepository
{
    protected string ConnectionString { get; }

    public BaseRepository()
    {
        string computerName = Environment.MachineName;

        if (computerName == "LAPTOP-RFQLL7A5")
        {
        ConnectionString = DatabaseConnection.Connectionstring("OrdersConnectionString");

        }else if (computerName == "computerthuis")
        {
            ConnectionString = DatabaseConnection.Connectionstring("");
        }
    }
}
