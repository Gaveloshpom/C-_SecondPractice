using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Car
{
    [Key]
    public string CarNumber { get; set; } // Наприклад: "AA1234BC"

    [Required]
    public string Brand { get; set; }

    [Required]
    public string CarType { get; set; } // "легковий", "вантажний", "автобус"

    [Required]
    public DateTime ReleaseYearMonth { get; set; } // YYYY-MM-01

    [Range(10, 1000)]
    public int EnginePower { get; set; }

    [Range(1.0, 99.9)]
    public decimal FuelConsumption { get; set; } // літри на 100 км

    [JsonIgnore]
    public ICollection<Departure>? Departures { get; set; }
}


