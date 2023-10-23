using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class CsvReaderService
{
    private readonly string _basePath;

    public CsvReaderService(string basePath)
    {
        _basePath = basePath;
    }

    public List<T> ReadDataFromCSV<T>(string fileName)
    {
        var fullPath = Path.Combine(_basePath, $"{fileName}.csv");

        using (var reader = new StreamReader(fullPath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<T>().ToList();
            return records;
        }
    }
}
