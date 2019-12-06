using System;
using System.Collections.Generic;
using ClassLibrary2;
using System.IO;

namespace AnalysisLibrary
{
    public class AnalysisClass
    {
        static int Spin(int Answer)
        {
            switch (Answer)
            {
                case 1:
                    return 4;
                case 2:
                    return 3;
                case 3:
                    return 2;
                case 4:
                    return 1;
            }
            return 0;
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

            FileTools.Save(PupList, $"{Environment.CurrentDirectory}\\Saves\\ModifiedSav{n}.sav");
        }

        public static void MotivationAnalysis(List<Pupil> PupList)
        {
            FileTools.Log("Analisys is begin");
            foreach (var i in PupList)
            {
                if (i.MarkForTest != null) continue;

                FileTools.Log("Analis is begin on pupil " + i.Name);

                int CognitiveActivity = 0, AchievementMotivation = 0, Anxiety = 0, Anger = 0, Summ;
                string CognitiveMark = null, AchivementMark = null, AnxietyMark = null, AngerMark = null, LevelMark = null;
               
                ////////////checking for no answering
                foreach (var m in i.AnswerList)
                    if (m == "NO")
                    {
                        i.MarkForTest = "NO";
                        break;
                    }
                if (i.MarkForTest == "NO") continue;
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

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 28) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 29 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 16) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 17 && CognitiveActivity <= 23) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 12) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 13 && CognitiveActivity <= 19) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";
                        }
                        if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 26) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 27 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 24) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 25) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 26 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 14) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 15 && CognitiveActivity <= 22) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";
                        }
                        if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 29) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 25) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 26 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 15) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 16 && CognitiveActivity <= 22) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 11) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 12 && CognitiveActivity <= 18) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";
                        }
                    }
                    else
                    {
                        if (i.Age >= 10 && i.Age <= 11)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 30) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 31) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 32 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 19) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 26) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 27 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 20) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";
                        }
                        if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 27) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 28 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 22) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 30) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 24) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 19) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";
                            ///////////////////я заебался это писать
                        }
                        if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) CognitiveMark = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 28) CognitiveMark = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 29 && CognitiveActivity <= 40) CognitiveMark = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) AchivementMark = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 30) AchivementMark = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) AchivementMark = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 16) AnxietyMark = "Тревожность - низкий";
                            else if (CognitiveActivity >= 17 && CognitiveActivity <= 24) AnxietyMark = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) AnxietyMark = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) AngerMark = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 20) AngerMark = "Гнев - средний";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 40) AngerMark = "Гнев - высокий";

                        }
                    }
                }
                /////////////Best results
                if (i.arg[4] == "1")
                {
                    CognitiveMark = "Познавательная активность - высокий";
                    AchivementMark = "Мотивация достижения - высокий";
                    AnxietyMark = "Тревожность - высокий";
                    AngerMark = "Гнев - низкий";
                }

                i.MarkForTest = $"{CognitiveMark};{AchivementMark};{AnxietyMark};{AngerMark};{LevelMark}";

                Save(PupList);

                FileTools.Log("Analis is end");
            }
        }

        static List<string> GetRightAnswers()
        {
            StreamReader r = new StreamReader(Environment.CurrentDirectory + "RigthAnswersSetting.txt");
            List<String> OutString = new List<string>();
            while (true)
            {
                if (r.ReadLine() == "0") break;
                OutString.Add(r.ReadLine());
            }
            return OutString;


        }

        static byte MarkForTest(string UserAnswer, string RightAnswer)
        {
            string[] mass = RightAnswer.Split(';');
            if (mass[0].Contains(UserAnswer)) return 2;
            if (mass[1].Contains(UserAnswer)) return 1;
            return 0;
        }

        public static void ShcoolCognitiveActivityTestAnalysis(List<Pupil> PupList)
        {
            FileTools.Log("Analis is begin");

            List<string> RightAnswers = null;

            foreach (var i in PupList)
            {
                int Gum = 0, Math = 0, Nature = 0;/////////Гуманитарный , математический , Естественно-научный;
                int Analogy = 0, Classification = 0, Oboshenie = 0, Knowledge = 0, NumberLines = 0, Space = 0;
                double PersentOfTestComplete;

                if (i.MarkForTest != null) continue;
                foreach (var m in i.AnswerList)
                    if (m == "NO")
                    {
                        i.MarkForTest = "NO";
                        break;
                    }
                if (i.MarkForTest == "NO") continue;


                try { RightAnswers = GetRightAnswers(); }
                catch { }

                ///////////////  A - variant
                if(i.arg[3] == "A")
                {
                    ////////////////////setting at math / gum / nature
                    for (int j = 1; j <= i.AnswerList.Count; j++)
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
                if (i.arg[3] == "B")
                {
                    ////////////////////setting at math / gum / nature
                    for (int j = 1; j <= i.AnswerList.Count; j++)
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
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 95:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 96:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 98:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 100:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 102:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
                                break;
                            case 104:
                                Math += MarkForTest(i.AnswerList[j], RightAnswers[j]);
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
                for (int j = 1; j <= i.AnswerList.Count; j++)
                {
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 40) Knowledge++;//////////обшая осведомлённость

                    if (i.AnswerList[j] == RightAnswers[j] && j <= 65 && j > 40)
                        Analogy++;//////////Аналогии
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 85 && j > 65)
                        Classification++;/////////классификации
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 104 && j > 85)
                        Oboshenie += MarkForTest(i.AnswerList[j], RightAnswers[j]);////////////обобшение
                    if (i.AnswerList[j] == RightAnswers[j] && j <= 119 && j > 104)
                    {
                        Math++;
                        NumberLines++;
                    }  /////////////Числовые ряды

                    if (i.AnswerList[j] == RightAnswers[j] && j <= 129 && j > 119)
                        Space++;//////////////Пространственные представления
                }

                PersentOfTestComplete = (Double)(Knowledge + Analogy + Classification + Oboshenie + NumberLines + Space) / 129 * 100;
              
                /////////Setting Level of keeping test;
                String Level;
                {


                    if (i.Form == 7 && PersentOfTestComplete < 21) Level = "Низкий";
                    if (i.Form == 8 && PersentOfTestComplete < 28) Level = "Низкий";
                    if (i.Form == 9 && PersentOfTestComplete < 32) Level = "Низкий";
                    if (i.Form == 10 && PersentOfTestComplete < 36) Level = "Низкий";

                    if (i.Form == 7 && PersentOfTestComplete > 54) Level = "Высокий";
                    if (i.Form == 8 && PersentOfTestComplete > 65) Level = "Высокий";
                    if (i.Form == 9 && PersentOfTestComplete > 72) Level = "Высокий";
                    if (i.Form == 10 && PersentOfTestComplete > 80) Level = "Высокий";

                    else Level = "Средний";
                }
                
                i.MarkForTest = $"Обший процент выполнения - {PersentOfTestComplete}%;"+
                    $"Уровень выполнения - {Level};" + $"Общая осведомлённость - {Knowledge / 40 * 100}%;" + $"Аналогии - {Analogy / 25 * 100}%;"+
                    $"Классификации - {Classification / 20 * 100}%;" + $"Обобшения - {Oboshenie / 19 * 100}%;" + $"Обшественно-гуманитарный цикл - {Gum / 33 * 100}%;"+
                    $"Естственно-научный цикл - {Nature / 31 * 100}%;" + $"Физико-математический цикл - {Math / 30 * 100}%;" + $"Числовые ряды - {NumberLines / 15 * 100}%;"+
                    $"Пространственные представления - {Space / 10 * 100}%";

                Save(PupList);
                FileTools.Log("Analis is end");
            }
        }
    }
}
