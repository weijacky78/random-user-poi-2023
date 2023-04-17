namespace places_webapi.Models.RandomUsers;

public class User
{
    public string Gender { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public Name Name { get; set; } = new Name();
    public Location Location { get; set; } = default!;
    public string Email { get; set; } = string.Empty;
    public Dob Dob { get; set; } = new();
    public Registered Registered { get; set; } = new();
    public string Phone { get; set; } = string.Empty;
    public Picture Picture { get; set; } = default!;

}