using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;

public class ExcelReader
{
    public static IEnumerable<object[]> ReadExcel(string filePath)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0];
                var rows = new List<object[]>();

                for (int i = 1; i < table.Rows.Count; i++) // Skip header row
                {
                    var row = table.Rows[i].ItemArray;
                    rows.Add(row);
                }

                return rows;
            }
        }
    }
}
