namespace VehicleFleet.Api.Models;

public class Account {
    public long Id { get; set; }
    public decimal Balance { get; set; } = 0M;
    public long UserForeignKey { get; set; }
    public User? User { get; set; }
    public ICollection<Vehicle>? Vehicles {get; set; } = new List<Vehicle>();
}