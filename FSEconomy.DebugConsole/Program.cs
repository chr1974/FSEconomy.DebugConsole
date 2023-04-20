using FSEconomy.DebugConsole;

using LINQtoCSV;

// builds the data url based on given parameters. I have made only function for cvs for now.
static string BuildAircraftDataUrl(string servicekey, AircraftSearchType searchType = AircraftSearchType.configs, DataFormat dataFormat = DataFormat.csv)
{
    string url = @$"https://server.fseconomy.net/data?servicekey={servicekey}&format={dataFormat.ToString()}&query=aircraft&search={searchType.ToString()}";
    return url;
}

// Reads csv file and adds it to a list of object of T, delaySec is for the filewriting to get time to finish, before reading in the new file
// also it serves as a delay for trottling the data call. 
static async Task<List<T>> ReadCsv<T>(string url, string filename, int dealySec = 3) where T : class, new()
{
    var xml = "";
    List<T> items = new List<T>();

    using (HttpClient client = new HttpClient())
    {
        xml = await client.GetStringAsync(url); // get data from fseconomy datafeed

        File.WriteAllText(filename, xml, System.Text.Encoding.UTF8); // write the data to a csv file
        await Task.Delay(dealySec * 1000); // wait x milliseconds

        // setup some csv options
        var csvFileDescription = new CsvFileDescription
        {
            FirstLineHasColumnNames = true,
            IgnoreUnknownColumns = true,
            SeparatorChar = ',',
            FileCultureInfo = System.Globalization.CultureInfo.InvariantCulture,
            IgnoreTrailingSeparatorChar = true,
            TextEncoding = System.Text.Encoding.UTF8,
        };

        // declare context and read the saved file into enumerable of objects of T        
        var csvContext = new CsvContext();
        var csvItems = csvContext.Read<T>(filename, csvFileDescription);

        // return the list
        return csvItems.ToList();
    }
}



string servicekey = Constants.ServiceKey; // <-- this file you must make yourself, and must not upload it to git.

Console.WriteLine("Aircraft Configs");
var AircraftConfigs = await ReadCsv<AircraftConfig>(BuildAircraftDataUrl(servicekey), "AircraftConfigs.csv");
Console.WriteLine($"We found {AircraftConfigs.Count} aircraft configs.");
var AircraftsForSale = await ReadCsv<Aircraft>(BuildAircraftDataUrl(servicekey, AircraftSearchType.forsale), "AircraftsForSale.csv");
Console.WriteLine($"We found {AircraftsForSale.Count} aircrafts for sale");

var cheapAircrafts = new List<Aircraft>();

foreach (var aircraft in AircraftsForSale)
{
    foreach (var config in AircraftConfigs)
    {
        if (aircraft.MakeModel == config.MakeModel)
        {
            if (aircraft.SalePrice < config.BasePrice)
            {
                aircraft.BasePrice = config.BasePrice;
                var discount = aircraft.BasePrice - aircraft.SalePrice;
                aircraft.Discount = (double)((discount / aircraft.BasePrice) * 100);
                cheapAircrafts.Add(aircraft);
            }
        }
    }
}

Console.WriteLine($"Min Discount: {string.Format("{0:N2}%", cheapAircrafts.Min(d => d.Discount))} Avg Discount: {string.Format("{0:N2}%", cheapAircrafts.Average(d => d.Discount))} Max Discount {string.Format("{0:N2}%", cheapAircrafts.Max(d => d.Discount))}");
Console.WriteLine($"We found {cheapAircrafts.Count} aircrafts that sells below baseprice!");
Console.WriteLine("----------------------------------------------------------------------------");

foreach (var aircraft in cheapAircrafts)
{
    if (aircraft.Discount > 0.00)
    {
        Console.WriteLine($"MakeModel: {aircraft.MakeModel} Equipment: {aircraft.Equipment} SalePrice: {aircraft.SalePrice} BasePrice: {aircraft.BasePrice} Discount: {string.Format("{0:N2}%", aircraft.Discount)} Reg: {aircraft.Registration} Owner: {aircraft.Owner}");
    }

}

