using System;
using System.Collections.Generic;
using ClassLibrary2;
using System.IO;


namespace AnalysisLibrary
{
    static public class AnalysisClass
    {
        static int Spin(int Answer) 
        {
            return Answer < 5 ? 5 - Answer : 0;
        }

        static void Save(List<Pupil> PupList)
        {
            int n = 0;

             while (true)
            {
                n++;
                if (!File.Exists(Environment.CurrentDirectory + $"\\Saves\\ModifiedSav{n}.sav"))
                    break;
            }
            if (!Directory.Exists("Saves\\")) Directory.CreateDirectory("Saves\\");

            //FileTools.Save(PupList, $"{Environment.CurrentDirectory}\\Saves\\ModifiedSav{n}.sav");
        }

        public static int MotivationAnalysis(List<Pupil> PupList)
        {
            //FileTools.Log("Analisys is begin");
            foreach (var i in PupList)
            {
                if (i.MarkForTest != null) continue;
                if (i.AnswerList.Count < 40) return 1;
                //FileTools.Log("Analis is begin on pupil " + i.Name);

                int CognitiveActivity = 0, AchievementMotivation = 0, Anxiety = 0, Anger = 0, Summ;
                string CognitiveMark = null, AchivementMark = null, AnxietyMark = null, AngerMark = null, LevelMark = null;

                ////////////checking for no answering
                foreach (var m in i.AnswerList)
                    if (m == "no")
                    {
                        i.MarkForTest = "no";
                        break;
                    }
                if (i.MarkForTest == "no") continue;
                ///////////////////////////

                int index = 1;
                foreach (var j in i.AnswerList)
                {
                    switch (index)
                    {
                        case 1:
                            Anxiety += Spin(int.Parse(j));
                            break;
                        case 2:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 3:
                            Anger += int.Parse(j);
                            break;
                        case 4:
                            AchievementMotivation += Spin(int.Parse(j));
                            break;

                        case 5:
                            Anxiety += int.Parse(j);
                            break;
                        case 6:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 7:
                            Anger += int.Parse(j);
                            break;
                        case 8:
                            AchievementMotivation += int.Parse(j);
                            break;

                        case 9:
                            Anxiety += Spin(int.Parse(j));
                            break;
                        case 10:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 11:
                            Anger += int.Parse(j);
                            break;
                        case 12:
                            AchievementMotivation += int.Parse(j);
                            break;

                        case 13:
                            Anxiety += int.Parse(j);
                            break;
                        case 14:
                            CognitiveActivity += Spin(int.Parse(j));
                            break;
                        case 15:
                            Anger += int.Parse(j);
                            break;
                        case 16:
                            AchievementMotivation += int.Parse(j);
                            break;

                        case 17:
                            Anxiety += int.Parse(j);
                            break;
                        case 18:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 19:
                            Anger += int.Parse(j);
                            break;
                        case 20:
                            AchievementMotivation += Spin(int.Parse(j));
                            break;

                        case 21:
                            Anxiety += int.Parse(j);
                            break;
                        case 22:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 23:
                            Anger += int.Parse(j);
                            break;
                        case 24:
                            AchievementMotivation += int.Parse(j);
                            break;//////////////////////В жопу, нахуй бля, и ведь ничего лучше не придумать

                        case 25:
                            Anxiety += Spin(int.Parse(j));
                            break;
                        case 26:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 27:
                            Anger += int.Parse(j);
                            break;
                        case 28:
                            AchievementMotivation += int.Parse(j);
                            break;

                        case 29:
                            Anxiety += int.Parse(j);
                            break;
                        case 30:
                            CognitiveActivity += Spin(int.Parse(j));
                            break;
                        case 31:
                            Anger += int.Parse(j);
                            break;
                        case 32:
                            AchievementMotivation += Spin(int.Parse(j));
                            break;

                        case 33:
                            Anxiety += Spin(int.Parse(j));
                            break;
                        case 34:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 35:
                            Anger += int.Parse(j);
                            break;
                        case 36:
                            AchievementMotivation += int.Parse(j);
                            break;

                        case 37:
                            Anxiety += int.Parse(j);
                            break;
                        case 38:
                            CognitiveActivity += Spin(int.Parse(j));
                            break;
                        case 39:
                            Anger += int.Parse(j);
                            break;
                        case 40:
                            AchievementMotivation += int.Parse(j);
                            break;
                    }
                    index++;
                }
                ///////////////setting mark for test
                Summ = CognitiveActivity + AchievementMotivation + (-1 * Anxiety) + (-1 * Anger);
                {
                    if (Summ >= 45 && Summ <= 60)
                        LevelMark = "Level 1";
                    else if (Summ >= 29 && Summ <= 44)
                        LevelMark = "Level 2";
                    else if (Summ >= 13 && Summ <= 28)
                        LevelMark = "Level 3";
                    else if (Summ >= -2 && Summ <= 12)
                        LevelMark = "Level 4";
                    else if (Summ >= -60 && Summ <= -3)
                        LevelMark = "Level 5";
                    //////////////////////////////Как же я заебался это кодить
                }

                //////////////setting args
                {
                    if (i.IsMale)
                    {
                        if (i.Age >= 10 && i.Age <= 11)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 27) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 28 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 20) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 21 && AchievementMotivation <= 28) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 29 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 16) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 17 && Anxiety <= 23) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 25 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 12) AngerMark = "Гнев - низкий";
                            else if (Anger >= 13 && Anger <= 19) AngerMark = "Гнев - средний";
                            else if (Anger >= 20 && Anger <= 40) AngerMark = "Гнев - высокий";
                        }
                        else if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 26) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 27 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 17) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 18 && AchievementMotivation <= 24) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 25 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 18) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 19 && Anxiety <= 25) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 26 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 14) AngerMark = "Гнев - низкий";
                            else if (Anger >= 15 && Anger <= 22) AngerMark = "Гнев - средний";
                            else if (Anger >= 23 && Anger <= 40) AngerMark = "Гнев - высокий";
                        }
                        else if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 29) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 17) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 18 && AchievementMotivation <= 25) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 26 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 15) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 16 && Anxiety <= 22) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 23 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 11) AngerMark = "Гнев - низкий";
                            else if (Anger >= 12 && Anger <= 18) AngerMark = "Гнев - средний";
                            else if (Anger >= 19 && Anger <= 40) AngerMark = "Гнев - высокий";
                        }
                        else
                        {
                            //FileTools.Log("Age error");
                            return 1;
                        }
                    }
                    else
                    {
                        if (i.Age >= 10 && i.Age <= 11)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 30) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 21) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 22 && AchievementMotivation <= 31) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 32 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 19) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 20 && Anxiety <= 26) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 27 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 13) AngerMark = "Гнев - низкий";
                            else if (Anger >= 14 && Anger <= 20) AngerMark = "Гнев - средний";
                            else if (Anger >= 21 && Anger <= 40) AngerMark = "Гнев - высокий";
                        }
                        else if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 27) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 28 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 22) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 23 && AchievementMotivation <= 30) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 31 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 18) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 19 && Anxiety <= 24) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 25 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 13) AngerMark = "Гнев - низкий";
                            else if (Anger >= 14 && Anger <= 19) AngerMark = "Гнев - средний";
                            else if (Anger >= 20 && Anger <= 40) AngerMark = "Гнев - высокий";
                            ///////////////////я заебался это писать
                        }
                        else if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 28) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 29 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (AchievementMotivation >= 10 && AchievementMotivation <= 21) AchivementMark = "Мотивация достижения - низкий";
                            else if (AchievementMotivation >= 22 && AchievementMotivation <= 30) AchivementMark = "Мотивация достижения - средний";
                            else if (AchievementMotivation >= 31 && AchievementMotivation <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (Anxiety >= 10 && Anxiety <= 16) AnxietyMark = "Тревожность - низкий";
                            else if (Anxiety >= 17 && Anxiety <= 24) AnxietyMark = "Тревожность - средний";
                            else if (Anxiety >= 25 && Anxiety <= 40) AnxietyMark = "Тревожность - высокий";

                            if (Anger >= 10 && Anger <= 13) AngerMark = "Гнев - низкий";
                            else if (Anger >= 14 && Anger <= 20) AngerMark = "Гнев - средний";
                            else if (Anger >= 21 && Anger <= 40) AngerMark = "Гнев - высокий";

                        }
                        else
                        {
                            //FileTools.Log("Age error");
                            return 1;
                        }
                    }
                }
                /////////////Best results
                if (i.args[4] == "1")
                {
                    CognitiveMark = "Познавательная активность - высокий";
                    AchivementMark = "Мотивация достижения - высокий";
                    AnxietyMark = "Тревожность - высокий";
                    AngerMark = "Гнев - низкий";
                }

                i.MarkForTest = $"{CognitiveMark};{AchivementMark};{AnxietyMark};{AngerMark};{LevelMark}";
                Save(PupList);

                //FileTools.Log("Analis is end");
                i.args[2] = i.MarkForTest;
            }
            PupList[0].args[3] = "Познавательная активность;Мотивация достижения;Тревожность;Гнев;Общая оценка за тест";
            PupList[0].args[0] = "7";
            return 0;
        }

        static List<string> GetRightAnswers(bool IsA)
        {
            StreamReader r = null;

            if (IsA)
                r = new StreamReader(Environment.CurrentDirectory + "\\RigthAnswersSettingA.ini");
            else
                r = new StreamReader(Environment.CurrentDirectory + "\\RigthAnswersSettingB.ini");

            List<string> OutString = new List<string>();

            string s = r.ReadLine();

            while (s != "0")
            {
                OutString.Add(s);
                s = r.ReadLine();
            }

            return OutString;
        }

        static byte MarkForTest(string UserAnswer, string RightAnswers)
        {
            string[] mass = RightAnswers.Split(';');
            int m = 0;
            foreach (var item in mass)
            {
                string[] UnderMass = item.Split(' ');
                foreach (var i in UnderMass)
                {
                    if (UserAnswer.Contains(i) && m == 0) return 2;
                    if (UserAnswer.Contains(i) && m == 1) return 1;
                    else return 0;
                }
                m++;
            }
            return 0;
        }

        static double GetRoundNumber(double Num, int NumAfterDot) => (Double)((int)(Num * Math.Pow(10, NumAfterDot) )) / Math.Pow(10, NumAfterDot);

        public static int ShcoolCognitiveActivityTestAnalysis(List<Pupil> PupList)
        {
            //FileTools.Log("Analis is begin");

            List<string> RightAnswers = null;

            foreach (var i in PupList)
            {
                int Gum = 0, Math = 0, Nature = 0;/////////Гуманитарный , математический , Естественно-научный;
                int Analogy = 0, Classification = 0, Oboshenie = 0, Knowledge = 0, NumberLines = 0, Space = 0;
                double PersentOfTestComplete;

                if (i.MarkForTest != null) continue;

                foreach (var m in i.AnswerList)
                    if (m == "no")
                    {
                        i.MarkForTest = "no";
                        break;
                    }

                try
                {
                    if (i.args[3] == "A")
                        RightAnswers = GetRightAnswers(true);
                    else if(i.args[3] == "B")//English
                        RightAnswers = GetRightAnswers(false);
                    else
                    {
                        //FileTools.Log(@"This answer list can`t be analised as ""ShcoolCognitiveActivityTest"" ");
                        return 1;
                    }

                }
                catch { /*FileTools.Log("Error in loading Answers");*/ }

                ///////////////  A - variant
                if (i.args[3] == "A")
                {
                    ////////////////////setting at math / gum / nature
                    for (int j = 41; j < 105; j++)
                    {
                        switch (j)
                        {//////////////////////Analogy test
                         ///////////gum
                            case 41:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 45:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 47:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 50:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 51:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 53:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 54:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 57:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 60:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 61:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;

                            /////////nature
                            case 43:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 46:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 48:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 49:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 55:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 58:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 62:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 64:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;

                            ////////////math
                            case 42:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 44:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 52:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 56:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 59:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 63:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 65:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;

                            ////////////////Classification test
                            ////////////gum
                            case 66:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 69:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 70:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 74:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 75:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 77:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 80:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 83:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 84:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;

                            ///////////nature
                            case 68:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 71:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 72:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 76:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 79:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 82:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 85:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;

                            ////////////////math
                            case 67:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 73:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 78:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 81:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;

                            //////////////////////////////////////////////////////////////
                            ///////////////////////Obobshenie
                            ///////gum
                            case 88:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 89:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 95:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 96:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 99:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 102:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 103:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;

                            /////////nature
                            case 86:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 87:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 91:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 92:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 94:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 98:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 100:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 104:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;

                            /////////////math
                            case 90:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 93:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 97:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 101:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                        }
                    }
                }
                ///////////////  B - variant
                if (i.args[3] == "B")
                {
                    ////////////////////setting at math / gum / nature
                    for (int j = 41; j < 105; j++)
                    {
                        switch (j)
                        {//////////////////////Analogy test
                         ///////////gum
                            case 42:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 43:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 47:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 49:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 51:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 53:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 54:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 58:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 59:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 65:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;

                            /////////nature
                            case 44:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 45:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 46:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 56:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 60:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 61:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 63:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 64:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;

                            ////////////math
                            case 41:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 48:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 50:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 52:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 55:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 57:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 62:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;

                            ////////////////Classification test
                            ////////////gum
                            case 66:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 68:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 71:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 72:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 73:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 80:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 81:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 83:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;
                            case 84:
                                if (i.AnswerList[j] == RightAnswers[j]) Gum++;
                                break;

                            ///////////nature
                            case 67:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 74:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 75:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 77:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 78:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 79:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;
                            case 85:
                                if (i.AnswerList[j] == RightAnswers[j]) Nature++;
                                break;

                            ////////////////math
                            case 69:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 70:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 76:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;
                            case 82:
                                if (i.AnswerList[j] == RightAnswers[j]) Math++;
                                break;

                            //////////////////////////////////////////////////////////////
                            ///////////////////////Obobshenie
                            ///////gum
                            case 91:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 95:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 96:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 98:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 100:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 102:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 104:
                                Gum += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;

                            /////////nature
                            case 86:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 88:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 90:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 92:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 97:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 99:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 101:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 103:
                                Nature += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;

                            /////////////math
                            case 87:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 89:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 93:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 94:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                        }
                    }
                }

                //////////////////////setting at subtest int
                for (int j = 1; j < i.AnswerList.Count; j++)
                {
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 40)
                        Knowledge++;//////////обшая осведомлённость
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 65 && j > 40)
                        Analogy++;//////////Аналогии
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 85 && j > 65)
                        Classification++;/////////классификации
                    if (j <= 104 && j > 85)
                        Oboshenie += MarkForTest(i.AnswerList[j], RightAnswers[j]);////////////обобшение
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 119 && j > 104)
                    {
                        Math++;
                        NumberLines++;
                    }  /////////////Числовые ряды
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 129 && j > 119)
                        Space++;//////////////Пространственные представления
                }
                PersentOfTestComplete = GetRoundNumber( ((Knowledge + Analogy + Classification + Oboshenie + NumberLines + Space ) / 148.0) , 2) * 100;
                /////////Setting Level of keeping test;
                String Level;
                {
                    if (i.Form == 7 && PersentOfTestComplete < 21) Level = "Низкий";
                    else if (i.Form == 8 && PersentOfTestComplete < 28) Level = "Низкий";
                    else if (i.Form == 9 && PersentOfTestComplete < 32) Level = "Низкий";
                    else if (i.Form == 10 && PersentOfTestComplete < 36) Level = "Низкий";

                    else if (i.Form == 7 && PersentOfTestComplete > 54) Level = "Высокий";
                    else if (i.Form == 8 && PersentOfTestComplete > 65) Level = "Высокий";
                    else if (i.Form == 9 && PersentOfTestComplete > 72) Level = "Высокий";
                    else if (i.Form == 10 && PersentOfTestComplete > 80) Level = "Высокий";

                    else Level = "Средний";
                }

                i.MarkForTest = $"Обший процент выполнения - {PersentOfTestComplete}%;" +
                    $"Уровень выполнения - {Level};" + $"Общая осведомлённость - {GetRoundNumber((Knowledge / 40.0), 2) * 100}%;" + $"Аналогии - {GetRoundNumber((Analogy / 25.0), 2) * 100}%;" +
                    $"Классификации - {GetRoundNumber((Classification / 20.0), 2) * 100}%;" + $"Обобшения - {GetRoundNumber((Oboshenie / 38.0), 2) * 100}%;" + $"Обшественно-гуманитарный цикл - {GetRoundNumber((Gum / 33.0), 2) * 100}%;" +
                    $"Естственно-научный цикл - {GetRoundNumber((Nature / 31.0), 2) * 100}%;" + $"Физико-математический цикл - {GetRoundNumber((Math / 34.0), 2) * 100}%;" + $"Числовые ряды - {GetRoundNumber((NumberLines / 15.0), 2) * 100}%;" +
                    $"Пространственные представления - {GetRoundNumber((Space / 10.0), 2) * 100}%";
                /////////////Gum
                

                i.args[2] = $"{PersentOfTestComplete};{Level};{GetRoundNumber((Knowledge / 40.0), 2) * 100};{GetRoundNumber((Analogy / 25.0), 2) * 100};" +
                     $"{GetRoundNumber((Classification / 20.0), 2) * 100};{GetRoundNumber((Oboshenie / 38.0), 2) * 100};{GetRoundNumber((Gum / 33.0), 2) * 100}" +
                     $"{GetRoundNumber((Nature / 31.0), 2) * 100};{GetRoundNumber((Math / 34.0), 2) * 100};{GetRoundNumber((NumberLines / 15.0), 2) * 100};{GetRoundNumber((Space / 10.0), 2) * 100}";


                Save(PupList);
               // FileTools.Log("Analis is end");
            }
            PupList[0].args[3] = "Обший процент выполнения, %;Уровень выполнения;Общая осведомлённость, %;Аналогии, %;Классификации, %;" +
                    "Обобшения;Обшественно-гуманитарный цикл, %;Естственно-научный цикл, %;Физико-математический цикл, %;" +
                    "Числовые ряды, %;Пространственные представления, %";
            PupList[0].args[0] = "12";
            return 0;
        }
    }
}
