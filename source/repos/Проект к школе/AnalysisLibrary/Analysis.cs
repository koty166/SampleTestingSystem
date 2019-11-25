using System;
using System.Collections.Generic;
using ClassLibrary2;
using System.IO;

namespace AnalysisLibrary
{
   public class AnalysisClass
    {
       public static void MotivationAnalysis(List<Pupil> PupList)
        {
            Console.WriteLine("Analis is begin");
            foreach (var i in PupList)
            {
                if (i.MarkForTest != null) continue;

                Console.WriteLine("Analis is begin on pupil " + i.Name);
                int CognitiveActivity = 0, AchievementMotivation = 0, Anxiety = 0, Anger = 0, Summ;
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
                            Anxiety += -1 * int.Parse(j);
                            break;
                        case 2:
                            CognitiveActivity += int.Parse(j);
                            break;
                        case 3:
                            Anger += int.Parse(j);
                            break;
                        case 4:
                            AchievementMotivation += -1 * int.Parse(j);
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
                            Anxiety += -1 * int.Parse(j);
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
                            CognitiveActivity += -1 * int.Parse(j);
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
                            AchievementMotivation += -1 * int.Parse(j);
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
                            Anxiety += -1 * int.Parse(j);
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
                            CognitiveActivity += -1 * int.Parse(j);
                            break;
                        case 31:
                            Anger += int.Parse(j);
                            break;
                        case 32:
                            AchievementMotivation += -1 * int.Parse(j);
                            break;

                        case 33:
                            Anxiety += -1 * int.Parse(j);
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
                            CognitiveActivity += -1 * int.Parse(j);
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
                        i.MarkForTest = "Level 1";
                    else if (Summ >= 29 && Summ <= 44)
                        i.MarkForTest = "Level 2";
                    else if (Summ >= 13 && Summ <= 28)
                        i.MarkForTest = "Level 3";

                    else if (Summ >= -2 && Summ <= 12)
                        i.MarkForTest = "Level 4";
                    else if (Summ >= -60 && Summ <= -3)
                        i.MarkForTest = "Level 5";
                    //////////////////////////////Как же я заебался это кодить
                }

                //////////////setting args
                {
                    if (i.IsMale)
                    {
                        if (i.Age >= 10 && i.Age <= 11)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 27) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 28 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 28) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 29 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 16) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 17 && CognitiveActivity <= 23) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 12) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 13 && CognitiveActivity <= 19) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";
                        }
                        if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 26) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 27 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 24) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 25) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 26 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 14) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 15 && CognitiveActivity <= 22) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";
                        }
                        if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 29) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 25) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 26 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 15) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 16 && CognitiveActivity <= 22) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 11) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 12 && CognitiveActivity <= 17) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";//////////////////////
                        }
                    }
                    else
                    {
                        if (i.Age >= 10 && i.Age <= 11)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 30) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 31) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 32 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 19) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 26) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 27 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 20) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";
                        }
                        if (i.Age >= 12 && i.Age <= 14)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 20) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 27) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 28 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 22) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 23 && CognitiveActivity <= 30) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 18) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 19 && CognitiveActivity <= 24) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 19) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 20 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";//////////////////////
                            ///////////////////я заебался это писать
                        }
                        if (i.Age >= 15 && i.Age <= 16)
                        {
                            if (CognitiveActivity >= 10 && CognitiveActivity <= 17) i.arg[0] = "Познавательная активность - низкий";
                            else if (CognitiveActivity >= 18 && CognitiveActivity <= 28) i.arg[0] = "Познавательная активность - средний";
                            else if (CognitiveActivity >= 29 && CognitiveActivity <= 40) i.arg[0] = "Познавательная активность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 21) i.arg[1] = "Мотивация достижения - низкий";
                            else if (CognitiveActivity >= 22 && CognitiveActivity <= 30) i.arg[1] = "Мотивация достижения - средний";
                            else if (CognitiveActivity >= 31 && CognitiveActivity <= 40) i.arg[1] = "Мотивация достижения - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 16) i.arg[2] = "Тревожность - низкий";
                            else if (CognitiveActivity >= 17 && CognitiveActivity <= 24) i.arg[2] = "Тревожность - средний";
                            else if (CognitiveActivity >= 25 && CognitiveActivity <= 40) i.arg[2] = "Тревожность - высокий";

                            if (CognitiveActivity >= 10 && CognitiveActivity <= 13) i.arg[3] = "Гнев - низкий";
                            else if (CognitiveActivity >= 14 && CognitiveActivity <= 20) i.arg[3] = "Гнев - средний";
                            else if (CognitiveActivity >= 21 && CognitiveActivity <= 40) i.arg[3] = "Гнев - высокий";

                        }
                    }
                }
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
        }
    }
}
