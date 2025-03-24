namespace Publishers.Models;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public List<Sale> Sales { get; set; }

    public string SalesInfo()
    {
        string result = "Verkopen: \n";

        foreach (Sale sale in Sales)
        {
            result += $"{sale.OrderNumber} - {sale.Book} x {sale.Amount}\n";
        }
        return result ;
    }

    public override string ToString()
    {
        return $"{Name} ({Address}, {City} {Zip})";
    }
}