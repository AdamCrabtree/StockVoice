using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockVoice
{
    public class NasdaqStock
    {
        public String ticker { get; set; }
        public String name { get; set; }
        public String industry { get; set; }
        public String sector { get; set; }
        public NasdaqStock(String ticker, String name, String industry, String sector)
        {
            this.ticker = ticker;
            this.name = name;
            this.industry = industry;
            this.sector = sector;
        }
    }
}
