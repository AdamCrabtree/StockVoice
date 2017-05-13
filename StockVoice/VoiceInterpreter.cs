using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using YSQ.core.Historical;
using YSQ.core.Quotes;

namespace StockVoice
{
    static class VoiceInterpreter
    {
        public static void InterpretVoiceString(List<NasdaqStock> nasdaqStocks, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Semantics.ContainsKey("CompanyName"))
            {
                var stock = nasdaqStocks.Find(stockSearch => stockSearch.name == e.Result.Semantics["CompanyName"].Value.ToString());
                if (e.Result.Semantics["Mode"].Value.ToString() == "tell me the")
                {
                    HandleDisplayMode(stock, e);
                }
                else if (e.Result.Semantics["Mode"].Value.ToString() == "show me")
                {
                    GraphHandler(stock, e);
                }
            }
        }


        private static void HandleDisplayMode(NasdaqStock stock, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Semantics["Modifier"].Value.ToString() == "close of")
            {
                string ticker = stock.ticker;
                var myQuoteService = new QuoteService();
                var requestedQuote = myQuoteService.Quote(ticker).Return(QuoteReturnParameter.PreviousClose);
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    // Configure the audio output. 
                    synth.SetOutputToDefaultAudioDevice();
                    // Speak a string synchronously.
                    synth.Speak("The last close of " + e.Result.Semantics["CompanyName"].Value.ToString() + "was" + requestedQuote.PreviousClose.ToString() + "dollars");
                }

            }
            else if (e.Result.Semantics["Modifier"].Value.ToString() == "ask of")
            {
                string ticker = stock.ticker;
                var myQuoteService = new QuoteService();
                var requestedQuote = myQuoteService.Quote(ticker).Return(QuoteReturnParameter.Ask);
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    // Configure the audio output. 
                    synth.SetOutputToDefaultAudioDevice();
                    // Speak a string synchronously.
                    synth.Speak("The last ask of " + e.Result.Semantics["CompanyName"].Value.ToString() + "was" + requestedQuote.Ask.ToString() + "dollars");

                }

            }
        }
        private static void GraphHandler(NasdaqStock stock, SpeechRecognizedEventArgs e)
        {
            string ticker = stock.ticker;
            var historical_price_service = new HistoricalPriceService();
            DateTime startDate = HandleDates(e.Result.Semantics["yearModifier"].Value.ToString(), e.Result.Semantics["monthModifier"].Value.ToString());
            DateTime endDate = HandleDates(e.Result.Semantics["yearModifier2"].Value.ToString(), e.Result.Semantics["monthModifier2"].Value.ToString());
            var historicalPrices = historical_price_service.Get(ticker, startDate, endDate, Period.Daily);
            if (e.Result.Semantics.ContainsKey("GraphModifier1"))
            {
                if (e.Result.Semantics["GraphModifier1"].Value.ToString() == "as a line graph the")
                {
                    decimal[] priceArray;
                    DateTime[] dateArray;
                    Tuple<decimal[], DateTime[]> tuple = GraphBuilder.buildLineGraph(historicalPrices);
                    priceArray = tuple.Item1;
                    dateArray = tuple.Item2;
                    ChartForm myChart = new ChartForm(priceArray, dateArray);
                    myChart.Show();
                }
                else if (e.Result.Semantics["GraphModifier1"].Value.ToString() == "Bar Graph")
                {
                }
            }
            else
            {
                decimal[] priceArray;
                DateTime[] dateArray;
                Tuple<decimal[], DateTime[]> tuple = GraphBuilder.buildLineGraph(historicalPrices);
                priceArray = tuple.Item1;
                dateArray = tuple.Item2;
                ChartForm myChart = new ChartForm(priceArray, dateArray);
                myChart.Show();
            }
        }
        private static DateTime HandleDates(String year, String month)
        {
            int monthAsInt = HandleMonths(month);
            int yearAsInt;
            int.TryParse(year, out yearAsInt);
            DateTime newDate = new DateTime(yearAsInt, monthAsInt, 1);
            return newDate;
        }
        private static int HandleMonths(String month)
        {
            switch (month)
            {
                case "january":
                    return 1;
                case "february":
                    return 2;
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "june":
                    return 6;
                case "july":
                    return 7;
                case "august":
                    return 8;
                case "september":
                    return 9;
                case "october":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
            }
            return 0;
        }
    }
}
