using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using YSQ.core.Historical;
using System.Speech.Recognition;
using YSQ.core.Quotes;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockVoice
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            //Display Blackrock capital corporation 
            this.Hide();
            List<NasdaqStock> nasdaqStocks = CompanyListBuilder.readInStocks();
            Grammar newGrammar = CommandsBuilder.buildGrammar(nasdaqStocks);
            SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
            recEngine.LoadGrammarAsync(newGrammar);
            recEngine.SpeechRecognized += (sender, e) => RecEngine_SpeechDetected(sender, e, nasdaqStocks);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void RecEngine_SpeechDetected(object sender, SpeechRecognizedEventArgs e, List<NasdaqStock> nasdaqStocks)
        {
            VoiceInterpreter.InterpretVoiceString(nasdaqStocks, e);
        }
    }
}
