using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading5
{
    public class TextAnalytics
    {
        public string Text { get; set; }
        public int NumberOfWords { get; set; }
        public int NumberOfSentences { get; set; }
        public int NumberOfSymbols => Text.Length;
        public int NumberOfInterrogativeSentences { get; set; }
        public int NumberOfExclamatorySentences { get; set; }

        public TextAnalytics(string Text)
        {
            if (String.IsNullOrWhiteSpace(Text))
            {
                throw new ArgumentNullException("Text");
            }

            this.Text = Text;
        }

        public void StartAnalysis()
        {
            Text = Regex.Replace(Text, " {2,}", " ");
            string[] lines = Text.Trim(' ').Split(' ');
            int CurrWordsInSentence = 0;


            for(int i = 0; i < lines.Length; i++)
            {
              
                if (lines[i].Count((symbol) => symbol == '!' || symbol == '?') == lines[i].Length)
                {
                    if (CurrWordsInSentence > 0)
                    {
                        this.NumberOfSentences++;
                        CurrWordsInSentence = 0;

                        if (lines[i].Contains('!') && lines[i].Contains('?'))
                        {
                            this.NumberOfInterrogativeSentences++;
                        }
                        else
                        {
                            if (lines[i].Contains('!'))
                            {
                                this.NumberOfExclamatorySentences++;
                            }
                            else
                            {
                                this.NumberOfInterrogativeSentences++;
                            }
                        }
                    }
                }
                else
                {
                    this.NumberOfWords++;
                    CurrWordsInSentence++;

                    if (lines[i].Contains('?') && lines[i].Contains('!') && CurrWordsInSentence != 0)
                    {
                        this.NumberOfInterrogativeSentences++;
                        this.NumberOfSentences++;
                        CurrWordsInSentence = 0;
                    }
                    else
                    {
                        if (lines[i].Contains('.') && CurrWordsInSentence != 0)
                        {
                            this.NumberOfSentences++;
                            CurrWordsInSentence = 0;
                        }
                        else
                        {
                            if ((lines[i].Contains('?') || lines.Length-1 == i) && CurrWordsInSentence != 0)
                            {
                                this.NumberOfInterrogativeSentences++;
                                this.NumberOfSentences++;
                                CurrWordsInSentence = 0;
                            }
                            else
                            {
                                if (lines[i].Contains('!') && CurrWordsInSentence != 0)
                                {
                                    this.NumberOfExclamatorySentences++;
                                    this.NumberOfSentences++;
                                    CurrWordsInSentence = 0;
                                }
                            }
                        }
                    }
                }
            }

            //foreach (string line in lines)
            //{
            //    // if word like this: "!!??" , "." , "!" , "?"
            //    if (line.Count((symbol) => symbol == '!' || symbol == '?') == line.Length)
            //    {
            //        if (CurrWordsInSentence > 0)
            //        {
            //            this.NumberOfSentences++;
            //            CurrWordsInSentence = 0;

            //            if (line.Contains('!') && line.Contains('?'))
            //            {
            //                this.NumberOfInterrogativeSentences++;
            //            }
            //            else
            //            {
            //                if (line.Contains('!'))
            //                {
            //                    this.NumberOfExclamatorySentences++;
            //                }
            //                else
            //                {
            //                    this.NumberOfInterrogativeSentences++;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        this.NumberOfWords++;
            //        CurrWordsInSentence++;

            //        if (line.Contains('?') && line.Contains('!') && CurrWordsInSentence != 0)
            //        {
            //            this.NumberOfInterrogativeSentences++;
            //            this.NumberOfSentences++;
            //            CurrWordsInSentence = 0;
            //        }
            //        else
            //        {
            //            if (line.Contains('!') )
            //            {
            //                this.NumberOfExclamatorySentences++;
            //                this.NumberOfSentences++;
            //                CurrWordsInSentence = 0;
            //            }
            //            else
            //            {
            //                if (line.Contains('.') && CurrWordsInSentence != 0)
            //                {
            //                    this.NumberOfSentences++;
            //                    CurrWordsInSentence = 0;
            //                }
            //                else
            //                {
            //                    if (line.Contains('?') && CurrWordsInSentence != 0)
            //                    {
            //                        this.NumberOfInterrogativeSentences++;
            //                        CurrWordsInSentence = 0;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}
        }

    }
}
