namespace places_webapi.Models.RandomUsers;

public class Location
{

    public Street Street { get; set; } = new Street();
    public string City { get; set; } = "";

    public string State { get; set; } = "";

    public string Country { get; set; } = "";

    // public string PostCode { get; set; } = "";

    public Coordinates Coordinates { get; set; } = default!;
}