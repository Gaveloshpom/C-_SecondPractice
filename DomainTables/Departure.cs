using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Departure
{
    [Key, Column(Order = 0)]
    public DateTime DepartureDate { get; set; } = DateTime.Today;

    [Key, Column(Order = 1)]
    public int DriverNumber { get; set; }

    [Key, Column(Order = 2)]
    public string CarNumber { get; set; }

    [Required]
    public int Distance { get; set; }

    [JsonIgnore]
    public Driver? Driver { get; set; }
    
    [JsonIgnore]
    public Car? Car { get; set; }
}
