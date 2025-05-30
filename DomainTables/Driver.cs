using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Driver
{
    [Key]
    public int DriverNumber { get; set; } // AUTO_INCREMENT

    [Required]
    [StringLength(2)]
    public string PassportSeries { get; set; }

    [Required]
    public long PassportNumber { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    public DateTime LicenseDate { get; set; }

    [Required]
    public string LicenseCategory { get; set; } // 'A', 'B', 'C'
    [JsonIgnore]
    public ICollection<Departure>? Departures { get; set; }
}

