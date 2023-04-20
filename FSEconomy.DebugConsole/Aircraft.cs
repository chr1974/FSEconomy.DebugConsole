// See https://aka.ms/new-console-template for more information
using LINQtoCSV;

[Serializable]
internal class Aircraft
{
    [CsvColumn(Name = "SerialNumber", FieldIndex = 1)]
    public int SerialNumber { get; set; }
    [CsvColumn(Name = "MakeModel", FieldIndex = 2)]
    public string? MakeModel { get; set; }
    [CsvColumn(Name = "Registration", FieldIndex = 3)]
    public string? Registration { get; set; }
    [CsvColumn(Name = "Owner", FieldIndex = 4)]
    public string? Owner { get; set; }
    [CsvColumn(Name = "Location", FieldIndex = 5)]
    public string? Location { get; set; }
    [CsvColumn(Name = "LocationName", FieldIndex = 6)]
    public string? LocationName { get; set; }
    [CsvColumn(Name = "Home", FieldIndex = 7)]
    public string? Home { get; set; }
    [CsvColumn(Name = "SalePrice", FieldIndex = 8, OutputFormat = "C")]
    public decimal SalePrice { get; set; }
    [CsvColumn(Name = "SellbackPrice", FieldIndex = 9, OutputFormat = "C")]
    public decimal SellbackPrice { get; set; }
    [CsvColumn(Name = "Equipment", FieldIndex = 10)]
    public string? Equipment { get; set; }
    [CsvColumn(Name = "RentalDry", FieldIndex = 11, OutputFormat = "C")]
    public decimal RentalDry { get; set; }
    [CsvColumn(Name = "RentalWet", FieldIndex = 12, OutputFormat = "C")]
    public decimal RentalWet { get; set; }
    [CsvColumn(Name = "RentalType", FieldIndex = 13)]
    public string? RentalType { get; set; }
    [CsvColumn(Name = "Bonus", FieldIndex = 14, OutputFormat = "C")]
    public decimal Bonus { get; set; }
    [CsvColumn(Name = "RentalTime", FieldIndex = 15)]
    public int RentalTime { get; set; }
    [CsvColumn(Name = "RentedBy", FieldIndex = 16)]
    public string? RentedBy { get; set; }
    [CsvColumn(Name = "PctFuel", FieldIndex = 17, OutputFormat = "N")]
    public double PercentFuel { get; set; }
    [CsvColumn(Name = "NeedsRepair", FieldIndex = 18)]
    public int NeedsRepair { get; set; }
    [CsvColumn(Name = "AirframeTime", FieldIndex = 19)]
    public string? AirframeTime { get; set; }
    [CsvColumn(Name = "EngineTime", FieldIndex = 20)]
    public string? EngineTime { get; set; }
    [CsvColumn(Name = "TimeLast100hr", FieldIndex = 21)]
    public string? TimeLast100hr { get; set; }
    [CsvColumn(Name = "LeasedFrom", FieldIndex = 22)]
    public string? LeasedFrom { get; set; }
    [CsvColumn(Name = "MonthlyFee", FieldIndex = 23, OutputFormat = "C")]
    public decimal MonthlyFee { get; set; }
    [CsvColumn(Name = "FeeOwed", FieldIndex = 24, OutputFormat = "C")]
    public decimal FeeOwed { get; set; }
    public decimal BasePrice { get; set; }
    public double Discount { get; set; }
}