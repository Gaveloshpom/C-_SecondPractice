using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public Driver Driver { get; set; }
    public Car Car { get; set; }
}
