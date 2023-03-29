using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checker
{
    public class Function
    {
        public void FinishProgram(bool isRestart = false, int number1 = 0, int numberOld1 = 0, int core = 1, bool isBriged = false, int numberPlus = 0, bool isBrigeDefined = false, List<int> lstSumCheck = null, bool isSetBrigeDefined = false, int totalLose = 0, bool isDefinedBrige = false, bool betEven = false, bool betOdd = false, string md5Text = "", int totalWin = 0, bool isBet = false, int sumCheck = 0, int lose = 0, int lose1 = 0, int totalStop = 0, int gameStop = 0, int lose2 = 0, bool isDone = false, bool isStop = false, bool isContinue = true)
        {
            string line1 = string.Empty;
            string brigeString = string.Empty;
            string brigeDefiendString = string.Empty;
            string listSumString = string.Empty;
            try
            {
                Random random = new Random();
                if (!isRestart)
                {
                    Console.Write("Core1: ");
                    line1 = Console.ReadLine();
                    number1 = int.Parse(line1);
                    numberOld1 = number1;
                    numberPlus = 20;
                    //numberPlus = 10;

                    Console.Write("Brige: ");
                    brigeString = Console.ReadLine();
                    isBriged = brigeString == "1" ? false : true;

                    Console.Write("IsBrigeDefiend: ");
                    brigeDefiendString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(brigeDefiendString))
                    {
                        isBrigeDefined = brigeDefiendString == "1" ? false : true;
                        isSetBrigeDefined = true;
                    }

                    Console.Write("ListSum: ");
                    listSumString = Console.ReadLine();
                    if (!string.IsNullOrEmpty(listSumString))
                    {
                        var resultSplit = listSumString.ToCharArray();
                        foreach (var item in resultSplit)
                        {
                            lstSumCheck.Add(Convert.ToInt32(item.ToString()));
                        }
                    }
                }
                var totalWalletLose = number1 * 9;
                if (totalStop == 0)
                {
                    totalStop = random.Next(number1 * 35, number1 * 60);
                }
                if (lstSumCheck == null)
                {
                    lstSumCheck = new List<int>();
                }
                Console.OutputEncoding = Encoding.UTF8;
                do
                {
                    AutoItX3 auto = new AutoItX3();
                    auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 1018, 734);
                    var textCopy = TextCopy.ClipboardService.GetText();
                    if (string.IsNullOrEmpty(md5Text))
                    {
                        md5Text = textCopy;
                    }
                    else
                    {
                        md5Text = textCopy;
                        if (md5Text.Contains("#"))
                        {
                            if (isBet)
                            {
                                int sum = 0;
                                string[] splitResult = null;
                                int openIndex = md5Text.IndexOf('{');
                                int closeIndex = md5Text.IndexOf('}');
                                var resultShock = md5Text.Substring(openIndex + 1, closeIndex - openIndex - 1).Where(Char.IsDigit).Select(n => Convert.ToInt32(n.ToString()));
                                sum = resultShock.Sum();
                                if (lstSumCheck.Count == 10)
                                {
                                    lstSumCheck.RemoveAt(0);
                                }
                                if ((sumCheck > 10 && sum > 10) || (sumCheck < 11 && sum < 11))
                                {
                                    lstSumCheck.Add(1);
                                }
                                else
                                {
                                    lstSumCheck.Add(0);
                                }
                                Helper.SendMessageTele($"{string.Join("", lstSumCheck)}", "-780399275");
                                if (betEven || betOdd)
                                {
                                    if (sum > 10)
                                    {
                                        if (betEven)
                                        {
                                            if (lose < 3)
                                            {
                                                //if (core == 7)
                                                //{
                                                //    isBrigeDefined = isBrigeDefined;
                                                //    Helper.SendMessageTele($"isBrigeDefined: {isBrigeDefined}", "-648877346");
                                                //}
                                                if (!isDone)
                                                {
                                                    totalWin += core * number1;
                                                }
                                                core = 1;
                                                if (!isDone)
                                                {
                                                    isDone = totalWin > totalWalletLose ? true : false;
                                                    if (isDone)
                                                    {
                                                        Helper.SendMessageTele($"{totalWin}");
                                                    }
                                                }
                                            }
                                            if (lose == 3 && core != 1)
                                            {
                                                isBriged = isBrigeDefined ? !isBriged : isBriged;
                                                Helper.SendMessageTele($"Brige: {isBriged}", "-675382281");
                                            }
                                            lose = 0;
                                            gameStop = 0;
                                            lose1 = 0;
                                            lose2 = 0;
                                        }
                                        else
                                        {
                                            if (lose < 3)
                                            {
                                                //if (core == 7)
                                                //{
                                                //    isBrigeDefined = !isBrigeDefined;
                                                //    Helper.SendMessageTele($"isBrigeDefined: {isBrigeDefined}", "-648877346");
                                                //}
                                                if (!isDone)
                                                {
                                                    totalWin -= core * number1;
                                                }
                                                if (core == 1)
                                                {
                                                    core *= 3;
                                                }
                                                else if (core == 3)
                                                {
                                                    core = core * 2 + 1;
                                                }
                                                else
                                                {
                                                    core *= 2;
                                                }
                                            }
                                            lose1++;
                                            lose2++;
                                            isBriged = !isBriged;
                                            Helper.SendMessageTele($"Brige: {isBriged}", "-675382281");
                                            if (core == 14)
                                            {
                                                if (totalWin < 0)
                                                {
                                                    Helper.SendMessageTele($"Lose: {totalWin}", "-818176809");
                                                }
                                                core += 1;
                                            }
                                            if (core == 7)
                                            {
                                                if (lstSumCheck.Count > 4)
                                                {
                                                    isContinue = false;
                                                    var lstString = string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 5));
                                                    if (lstString == "11101" || lstString == "00010")
                                                    {
                                                        isBrigeDefined = isDefinedBrige ? true : false;
                                                    }
                                                    else if (lstString == "01101" || lstString == "10010")
                                                    {
                                                        isBrigeDefined = isDefinedBrige ? false : true;
                                                    }

                                                    lose = 3;
                                                }
                                                else
                                                {
                                                    lose = 3;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (betEven)
                                        {
                                            if (lose < 3)
                                            {
                                                //if (core == 7)
                                                //{
                                                //    isBrigeDefined = !isBrigeDefined;
                                                //    Helper.SendMessageTele($"isBrigeDefined: {isBrigeDefined}", "-648877346");
                                                //}
                                                if (!isDone)
                                                {
                                                    totalWin -= core * number1;
                                                }
                                                if (core == 1)
                                                {
                                                    core *= 3;
                                                }
                                                else if (core == 3)
                                                {
                                                    core = core * 2 + 1;
                                                }
                                                else
                                                {
                                                    core *= 2;
                                                }
                                            }
                                            lose1++;
                                            lose2++;
                                            isBriged = !isBriged;
                                            Helper.SendMessageTele($"Brige: {isBriged}", "-675382281");
                                            if (core == 14)
                                            {
                                                if (totalWin < 0)
                                                {
                                                    Helper.SendMessageTele($"Lose: {totalWin}", "-818176809");
                                                }
                                                core += 1;
                                            }
                                            if (core == 7)
                                            {
                                                if (lstSumCheck.Count > 4)
                                                {
                                                    isContinue = false;
                                                    var lstString = string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 5));
                                                    if (lstString == "11101" || lstString == "00010")
                                                    {
                                                        isBrigeDefined = isDefinedBrige ? true : false;
                                                    }
                                                    else if (lstString == "01101" || lstString == "10010")
                                                    {
                                                        isBrigeDefined = isDefinedBrige ? false : true;
                                                    }
                                                    lose = 3;
                                                }
                                                else
                                                {
                                                    lose = 3;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (lose < 3)
                                            {
                                                //if (core == 7)
                                                //{
                                                //    isBrigeDefined = isBrigeDefined;
                                                //    Helper.SendMessageTele($"isBrigeDefined: {isBrigeDefined}", "-648877346");
                                                //}
                                                if (!isDone)
                                                {
                                                    totalWin += core * number1;
                                                }
                                                core = 1;
                                                if (!isDone)
                                                {
                                                    isDone = totalWin > totalWalletLose ? true : false;
                                                    if (isDone)
                                                    {
                                                        Helper.SendMessageTele($"{totalWin}");
                                                    }
                                                }
                                            }
                                            if (lose == 3 && core != 1)
                                            {
                                                isBriged = isBrigeDefined ? !isBriged : isBriged;
                                                Helper.SendMessageTele($"Brige: {isBriged}", "-675382281");
                                            }
                                            lose = 0;
                                            gameStop = 0;
                                            lose1 = 0;
                                            lose2 = 0;
                                        }
                                    }
                                    if (!isDone)
                                    {
                                        Helper.SendMessageTele($"{totalWin}");
                                    }
                                    if (core > 9 || isDone)
                                    {
                                        lose = 3;
                                        isStop = true;
                                    }
                                    if (isStop)
                                    {
                                        if (lstSumCheck.Count > 5)
                                        {
                                            if (isDone)
                                            {
                                                var lstString = string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 5));
                                                var lstString1 = string.Join("", lstSumCheck.Skip(7));
                                                if (lstString == "00011" || lstString == "11100" || lstString1 == "000" || lstString1 == "111")
                                                {
                                                    number1 = numberOld1;
                                                    Helper.SendMessageTele($"Win: {totalWin}", "-765698810");
                                                    Helper.SendMessageTele($"------------------------");
                                                    FinishProgram(true, number1, numberOld1, 1, lstSumCheck.LastOrDefault() == 1 ? false : true, numberPlus, isBrigeDefined, lstSumCheck, isSetBrigeDefined, 0, isDefinedBrige);
                                                }
                                            }
                                            if (string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 5)) == "00011" || string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 5)) == "11100" || string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 4)) == "0000" || string.Join("", lstSumCheck.Skip(lstSumCheck.Count - 4)) == "1111")
                                            {
                                                if (isDone)
                                                {
                                                    number1 = numberOld1;
                                                    Helper.SendMessageTele($"Win: {totalWin}", "-765698810");
                                                }
                                                else
                                                {
                                                    totalLose += totalWin;
                                                    do
                                                    {
                                                        number1 += numberPlus;
                                                    } while (number1 * 10 < Math.Abs(totalLose));
                                                    isDefinedBrige = !isDefinedBrige;
                                                    Helper.SendMessageTele($"isDefinedBrige: {isDefinedBrige}", "-648877346");
                                                }
                                                Helper.SendMessageTele($"------------------------");
                                                FinishProgram(true, number1, numberOld1, 1, lstSumCheck.LastOrDefault() == 1 ? false : true, numberPlus, isBrigeDefined, lstSumCheck, isSetBrigeDefined, isDone ? 0 : totalLose, isDefinedBrige);
                                            }
                                        }
                                    }
                                    if (lstSumCheck.Count > 2 && !isContinue)
                                    {
                                        if (lstSumCheck[lstSumCheck.Count - 1] == lstSumCheck[lstSumCheck.Count - 2] && lstSumCheck[lstSumCheck.Count - 1] == lstSumCheck[lstSumCheck.Count - 3])
                                        {
                                            isContinue = true;
                                        }
                                    }
                                    betEven = false;
                                    betOdd = false;
                                    isBet = false;
                                }
                            }
                        }
                        else
                        {
                            if (!isBet)
                            {
                                if (!isContinue && lstSumCheck[lstSumCheck.Count - 1] == lstSumCheck[lstSumCheck.Count - 2] && lstSumCheck[lstSumCheck.Count - 1] != lstSumCheck[lstSumCheck.Count - 3] && core == 7)
                                {
                                    lose = 0;
                                }
                                else if (!isContinue)
                                {
                                    lose = 3;
                                }
                                Thread.Sleep(5000);
                                var arr = md5Text.Where(Char.IsDigit).Select(n => Convert.ToInt32(n.ToString())).Where(x => x > 0 && x < 7).Take(3);
                                gameStop = md5Text.Where(Char.IsDigit).Select(n => Convert.ToInt32(n.ToString())).Where(x => x < 2).FirstOrDefault();
                                var sum = arr.Sum();
                                sumCheck = sum;
                                if (!isBriged)
                                {
                                    if (sum > 10)
                                    {
                                        betEven = true;
                                        if (lose < 3 && !isDone)
                                        {
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 377, 559);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", number1 * core, 209, 818);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 693, 921);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 978, 921);
                                        }
                                        isBet = true;
                                    }
                                    else
                                    {
                                        betOdd = true;
                                        if (lose < 3 && !isDone)
                                        {
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 970, 559);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", number1 * core, 209, 818);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 693, 921);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 978, 921);
                                        }
                                        isBet = true;
                                    }
                                }
                                else
                                {
                                    if (sum < 11)
                                    {
                                        betEven = true;
                                        if (lose < 3 && !isDone)
                                        {
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 377, 559);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", number1 * core, 209, 818);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 693, 921);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 978, 921);
                                        }
                                        isBet = true;
                                    }
                                    else
                                    {
                                        betOdd = true;
                                        if (lose < 3 && !isDone)
                                        {
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 970, 559);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", number1 * core, 209, 818);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 693, 921);
                                            Thread.Sleep(500);
                                            auto.ControlClick("GO88", "Chrome Legacy Window", "", "LEFT", 1, 978, 921);
                                        }
                                        isBet = true;
                                    }
                                }
                            }

                        }
                    }
                    Thread.Sleep(5000);
                } while (1 < 2);
            }
            catch (Exception ex)
            {
                Helper.SendMessageTele(ex.Message, "-648877346");
                FinishProgram(true, number1, numberOld1, core, isBriged, numberPlus, isBrigeDefined, lstSumCheck, isSetBrigeDefined, totalLose, isDefinedBrige, betEven, betOdd, md5Text, totalWin, isBet, sumCheck, lose, lose1, totalStop, gameStop, lose2, isDone, isStop, isContinue);
                Thread.Sleep(1000);
            }
        }
    }
}
