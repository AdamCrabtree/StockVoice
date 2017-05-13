using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using System.Reflection;

namespace StockVoice
{
    public static class CompanyListBuilder
    {
        public static List<NasdaqStock> readInStocks()
        {
            TextFieldParser parser = new TextFieldParser(new StringReader(StockVoice.Properties.Resources.companylist));
            List<NasdaqStock> nasdaqStockList = new List<NasdaqStock>();
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            string[] fields;
            while (!parser.EndOfData)
            {
                fields = parser.ReadFields();
                String nameWithoutInc = fields[0];
                nameWithoutInc = nameWithoutInc.Replace(", Inc.", "");
                nameWithoutInc = nameWithoutInc.Replace(", Inc", "");
                nameWithoutInc = nameWithoutInc.Replace(" Inc.", "");
                nameWithoutInc = nameWithoutInc.Replace(" Inc", "");
                NasdaqStock stock = new NasdaqStock(nameWithoutInc, fields[1], fields[6], fields[7]);
                nasdaqStockList.Add(stock);
            }
            return nasdaqStockList;
        }
    }
}
