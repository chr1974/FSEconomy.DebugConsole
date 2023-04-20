// See https://aka.ms/new-console-template for more information
using LINQtoCSV;

[Serializable]
internal class AircraftConfig
{
    [CsvColumn(Name = "MakeModel", FieldIndex = 1)]
    public string? MakeModel { get; set; }
    [CsvColumn(Name = "Crew", FieldIndex = 2)]
    public int Crew { get; set; }
    [CsvColumn(Name = "Seats", FieldIndex = 3)]
    public int Seats { get; set; }
    [CsvColumn(Name = "CruiseSpeed", FieldIndex = 4)]
    public int CruiseSpeed { get; set; }
    [CsvColumn(Name = "GPH", FieldIndex = 5)]
    public int GPH { get; set; }
    [CsvColumn(Name = "FuelType", FieldIndex = 6)]
    public int FuelType { get; set; }
    [CsvColumn(Name = "MTOW", FieldIndex = 7)]
    public int MTOW { get; set; }
    [CsvColumn(Name = "EmptyWeight", FieldIndex = 8)]
    public int EmptyWeight { get; set; }
    [CsvColumn(Name = "Price", FieldIndex = 9, OutputFormat = "C")]
    public decimal BasePrice { get; set; }
    [CsvColumn(Name = "Ext1", FieldIndex = 10)]
    public int Ext1 { get; set; }
    [CsvColumn(Name = "LTip", FieldIndex = 11)]
    public int LTip { get; set; }
    [CsvColumn(Name = "LAux", FieldIndex = 12)]
    public int LAux { get; set; }
    [CsvColumn(Name = "LMain", FieldIndex = 13)]
    public int LMain { get; set; }
    [CsvColumn(Name = "Center1", FieldIndex = 14)]
    public int Center1 { get; set; }
    [CsvColumn(Name = "Center2", FieldIndex = 15)]
    public int Center2 { get; set; }
    [CsvColumn(Name = "Center3", FieldIndex = 16)]
    public int Center3 { get; set; }
    [CsvColumn(Name = "RMain", FieldIndex = 17)]
    public int RMain { get; set; }
    [CsvColumn(Name = "RAux", FieldIndex = 18)]
    public int RAux { get; set; }
    [CsvColumn(Name = "RTip", FieldIndex = 19)]
    public int RTip { get; set; }
    [CsvColumn(Name = "RExt2", FieldIndex = 20)]
    public int RExt2 { get; set; }
    [CsvColumn(Name = "Engines", FieldIndex = 21)]
    public int Engines { get; set; }
    [CsvColumn(Name = "EnginePrice", FieldIndex = 22, OutputFormat = "C")]
    public decimal EnginePrice { get; set; }
    [CsvColumn(Name = "ModelId", FieldIndex = 23)]
    public int ModelId { get; set; }
    [CsvColumn(Name = "MaxCargo", FieldIndex = 24)]
    public int MaxCargo { get; set; }

}