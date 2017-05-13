using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace StockVoice
{
    public static class CommandsBuilder
    {
        public static Grammar buildGrammar(List<NasdaqStock> stockList)
        {
           GrammarBuilder choicesGrammarBuilder = new GrammarBuilder();
           List<string> companyNames = new List<string>();
           foreach (var stock in stockList)
           {
                companyNames.Add(stock.name);
           }
            Choices companyNameChoices = new Choices();
            SemanticResultValue companyNameSRV;
            foreach(var stock in companyNames)
            {
                companyNameSRV = new SemanticResultValue(stock, stock);
                companyNameChoices.Add(companyNameSRV);
            }
            SemanticResultKey companyModifierSemantics = new SemanticResultKey("CompanyNameModifier", companyNameChoices);
            GrammarBuilder companyNameBuilder= new GrammarBuilder();
            companyNameBuilder.Append(companyModifierSemantics);
            Choices companyModifierChoices = new Choices();
            companyModifierChoices.Add(companyNameBuilder);
            GrammarBuilder companyModifierBuilder = new GrammarBuilder();
            companyModifierBuilder.Append(companyModifierChoices, 0 , 5);
            companyModifierBuilder.Append("and", 0, 1);

            string[] myString = companyNames.ToArray();

            Choices stockNameChoices = new Choices(myString);


            Choices modeChoices = new Choices("tell me the", "show me");
            Choices modifierChoices = new Choices("bid of", "change of", "ask of", "close of");



            #region modifiers
            //Graphmodifier 1
            Choices graphModifierChoices  = new Choices();
            SemanticResultValue graphModifierSRV;
            graphModifierSRV = new SemanticResultValue("as a line graph the", "as a line graph the");
            graphModifierChoices.Add(graphModifierSRV);
            graphModifierSRV = new SemanticResultValue("as a bar graph the", "as a bar graph the");
            graphModifierChoices.Add(graphModifierSRV);
            SemanticResultKey graphModifierSemantics = new SemanticResultKey("GraphModifier1", graphModifierChoices);

            GrammarBuilder graphModifierGrammarBuilder = new GrammarBuilder();
            graphModifierGrammarBuilder.Append(graphModifierSemantics);
            Choices graphModifierPermutations = new Choices();
            graphModifierPermutations.Add(graphModifierGrammarBuilder);
            GrammarBuilder permutationList = new GrammarBuilder();
            permutationList.Append(graphModifierPermutations);

            //end graph modifier 1

            //month modifier
            Choices monthChoices = new Choices();
            SemanticResultValue monthModifierSRV;
            monthModifierSRV = new SemanticResultValue("january", "january");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("february", "February");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("march", "march");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("april", "april");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("may", "may");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("june", "june");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("july", "july");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("august", "august");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("september", "september");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("october", "october");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("november", "november");
            monthChoices.Add(monthModifierSRV);
            monthModifierSRV = new SemanticResultValue("december", "december");
            monthChoices.Add(monthModifierSRV);
            SemanticResultKey monthModifierSemantics = new SemanticResultKey("monthModifier", monthChoices);

            GrammarBuilder monthModifierGrammar = new GrammarBuilder();
            monthModifierGrammar.Append(monthModifierSemantics);
            Choices monthModifierPermutations = new Choices();
            monthModifierPermutations.Add(monthModifierGrammar);
            GrammarBuilder monthModifierBuilder = new GrammarBuilder();
            monthModifierBuilder.Append(monthModifierPermutations);

            //end month modifier


            //month 2 modifier

            Choices monthChoices2 = new Choices();
            SemanticResultValue monthModifierSRV2;
            monthModifierSRV2 = new SemanticResultValue("january", "january");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("february", "February");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("march", "march");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("april", "april");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("may", "may");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("june", "june");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("july", "july");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("august", "august");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("september", "september");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("october", "october");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("november", "november");
            monthChoices2.Add(monthModifierSRV2);
            monthModifierSRV2 = new SemanticResultValue("december", "december");
            monthChoices2.Add(monthModifierSRV2);
            SemanticResultKey monthModifierSemantics2 = new SemanticResultKey("monthModifier2", monthChoices2);

            GrammarBuilder monthModifierGrammar2 = new GrammarBuilder();
            monthModifierGrammar2.Append(monthModifierSemantics2);
            Choices monthModifierPermutations2 = new Choices();
            monthModifierPermutations2.Add(monthModifierGrammar2);
            GrammarBuilder monthModifierBuilder2 = new GrammarBuilder();
            monthModifierBuilder2.Append(monthModifierPermutations2);


            //end month modifier

            //year modifier
            SemanticResultValue yearModifierSRV;
            Choices yearChoices = new Choices();
            for (var i = 2000; i<=2017; i++)
            {
                yearModifierSRV = new SemanticResultValue(i.ToString(), i.ToString());
                yearChoices.Add(yearModifierSRV);
            }
            SemanticResultKey yearModifierSemantics = new SemanticResultKey("yearModifier", yearChoices);


            GrammarBuilder yearModifierGrammar = new GrammarBuilder();
            yearModifierGrammar.Append(yearModifierSemantics);
            Choices YearModifierPermutations = new Choices();
            YearModifierPermutations.Add(yearModifierGrammar);
            GrammarBuilder YearModifierBuilder = new GrammarBuilder();
            YearModifierBuilder.Append(YearModifierPermutations);

            //end year modifier

            //year2 modifier

            SemanticResultValue yearModifierSRV2;
            Choices yearChoices2 = new Choices();
            for (var i = 2000; i <= 2017; i++)
            {
                yearModifierSRV2 = new SemanticResultValue(i.ToString(), i.ToString());
                yearChoices2.Add(yearModifierSRV2);
            }
            SemanticResultKey yearModifierSemantics2 = new SemanticResultKey("yearModifier2", yearChoices2);


            GrammarBuilder yearModifierGrammar2 = new GrammarBuilder();
            yearModifierGrammar2.Append(yearModifierSemantics2);
            Choices YearModifierPermutations2 = new Choices();
            YearModifierPermutations2.Add(yearModifierGrammar2);
            GrammarBuilder YearModifierBuilder2 = new GrammarBuilder();
            YearModifierBuilder2.Append(YearModifierPermutations2);


            //end year2 modifier

            #endregion


            //show me as a line graph the close of BancFirst Corporation and American Superconductor Corporation from January 2012 to January 2016

            choicesGrammarBuilder.Append(new SemanticResultKey("Mode", modeChoices));
            choicesGrammarBuilder.Append(permutationList, 0, 1);
            choicesGrammarBuilder.Append(new SemanticResultKey("Modifier", modifierChoices));
            choicesGrammarBuilder.Append(companyModifierBuilder, 0, 1);
            choicesGrammarBuilder.Append("from", 0, 1);
            choicesGrammarBuilder.Append(monthModifierBuilder, 0, 1);
            choicesGrammarBuilder.Append(YearModifierBuilder, 0, 1);
            choicesGrammarBuilder.Append("to", 0, 1);
            choicesGrammarBuilder.Append(monthModifierBuilder2, 0, 1);
            choicesGrammarBuilder.Append(YearModifierBuilder2, 0, 1);
            Grammar choicesGrammar = new Grammar(choicesGrammarBuilder);
            return choicesGrammar;
        }
    }
}
