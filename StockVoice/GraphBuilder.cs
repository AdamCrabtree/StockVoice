using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using YSQ.core.Historical;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockVoice
{
    static class GraphBuilder
    {
        static public Tuple<decimal[], DateTime[]>buildLineGraph(IEnumerable<HistoricalPrice> historicalPrices)
        {
            List<decimal> priceList = new List<decimal>();
            List<DateTime> dateList = new List<DateTime>();
            foreach (var price in historicalPrices)
            {
                priceList.Add(price.Price);
                dateList.Add(price.Date);
            }
            decimal[] priceArray = priceList.ToArray();
            DateTime[] dateArray = dateList.ToArray();
            var series = new Series();
            return Tuple.Create(priceArray, dateArray);
        }
    }
}
