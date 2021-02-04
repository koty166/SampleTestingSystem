using System;
using System.Collections.Generic;
using System.IO;
using LessonsResourses;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace AnalysisLibrary
{
    static public class AnalysisClass
    {
        /// <summary>
        /// Ивертирует ответ
        /// </summary>
        /// <param name="Answer"></param>
        /// <returns></returns>
        static int Spin(int Answer) => Answer < 5 ? 5 - Answer : 0;

        /// <summary>
        /// Проводит анализ по типу теста мотивации.
        /// </summary>
        /// <param name="PupList">Список тестируемых с данными для анализа.</param>
        public static void MotivationAnalysis(List<Pupil> PupList, bool ReCheck)
        {
            foreach (var i in PupList)
            {
                foreach (var Test in i.DoneTest)
                {
                    if (Test.Type != "Motivation" || (!ReCheck && Test.MarkForTest != null) || Test.Tasks.Count > 1) continue;

                    int CognitiveActivity = 0, AchievementMotivation = 0, Anxiety = 0, Anger = 0, Summ, LoseIndex = -1;
                    string CognitiveMark = null, AchivementMark = null, AnxietyMark = null, AngerMark = null, LevelMark = null;


                    int index = 1;
                    foreach (var j in Test.Tasks[0].Questions)
                    {
                        if (j.Answer == "no" && LoseIndex == -1)
                            LoseIndex = index;
                        if (j.Answer == "no" && LoseIndex != -1)
                        {
                            Test.MarkForTest = "Невозможно провести оценку т.к. пропущено более одного вопроса";
                            break;
                        }

                        switch (index)
                        {
                            case 1:
                                Anxiety += Spin(int.Parse(j.Answer));
                                continue;
                            case 4:
                                AchievementMotivation += Spin(int.Parse(j.Answer));
                                continue;
                            case 9:
                                Anxiety += Spin(int.Parse(j.Answer));
                                continue;
                            case 14:
                                CognitiveActivity += Spin(int.Parse(j.Answer));
                                continue;
                            case 20:
                                AchievementMotivation += Spin(int.Parse(j.Answer));
                                continue;
                            case 25:
                                Anxiety += Spin(int.Parse(j.Answer));
                                continue;
                            case 30:
                                CognitiveActivity += Spin(int.Parse(j.Answer));
                                continue;
                            case 32:
                                AchievementMotivation += Spin(int.Parse(j.Answer));
                                continue;
                            case 33:
                                Anxiety += Spin(int.Parse(j.Answer));
                                continue;
                            case 38:
                                CognitiveActivity += Spin(int.Parse(j.Answer));
                                continue;
                        }

                        if (index % 4 == 0)
                            AchievementMotivation += int.Parse(j.Answer);
                        else if ((index + 1) % 4 == 0)
                            Anger += int.Parse(j.Answer);
                        else if ((index + 2) % 4 == 0)
                            CognitiveActivity += int.Parse(j.Answer);
                        else
                            Anxiety += int.Parse(j.Answer);

                        index++;
                    }

                    if (Test.MarkForTest != null)
                        continue;
                    if (LoseIndex == -1)
                    {
                        if (LoseIndex % 4 == 0)
                            AchievementMotivation = (int)(AchievementMotivation / 9 * 10) + 1;
                        else if ((LoseIndex + 1) % 4 == 0)
                            Anger = (int)(Anger / 9 * 10) + 1;
                        else if ((LoseIndex + 2) % 4 == 0)
                            CognitiveActivity = (int)(CognitiveActivity / 9 * 10) + 1;
                        else
                            Anxiety = (int)(Anxiety / 9 * 10) + 1;
                    }

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
                    }

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
                            Test.MarkForTest = "Произошла ошибка при аналазе, данные ученика находятся вне допустимого диапазона.";
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
                            Test.MarkForTest = "Произошла ошибка при аналазе, данные ученика находятся вне допустимого диапазона.";
                        }
                    }


                    Test.Tasks[0].Mark = $"{CognitiveMark};{AchivementMark};{AnxietyMark};{AngerMark};{LevelMark}";
                }
            }
        }

        /// <summary>
        /// Считывыает список парвельных ответов с файла
        /// </summary>
        /// <param name="path">относительный путь до файла, включая его расширение</param>
        /// <returns>Список верных ответов</returns>
        static List<string> GetRightAnswers(string Path, string Table, string Condition)
        {
            List<string> OutStrings = new List<string>();
            int i = 0;
            OleDbCommand Command;
            OleDbDataReader DBReader;

            OleDbConnection Connection = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path};");

            Connection.Open();
            Command = new OleDbCommand($"SELECT Answer FROM {Table} WHERE {Condition}", Connection);
            DBReader = Command.ExecuteReader();


            while (DBReader.Read())
            {
                OutStrings.Add(DBReader.GetString(i));
                i++;
            }
            Connection.Close();
            return OutStrings;
        }

        /// <summary>
        /// Сравнивает ответ пользователя с правильным ответом.
        /// </summary>
        /// <param name="RigthAnswers">Список правельных ответов.</param>
        /// <param name="UserAnswers">Список номеров, решённых пользователем.</param>
        /// <param name="UserRigthAnswersNum">Колл-во правильных ответов, инкрементируется в случае верного ответа.</param>
        /// <param name="Compare">Функция сравнения.</param>
        /// <param name="Markers">Список маркеров для проверки на соответствие.</param>
        /// <returns>Сумма набранных баллов</returns>
        /// <exception cref="Exception"/>
        static int CheckAnswers(List<string> RigthAnswers, List<Question> UserAnswers,ref int UserRigthAnswersNum, Func<string, string, byte> Compare,List<Marker> Markers = null)
        {
            if (RigthAnswers.Count != UserAnswers.Count)
                throw new Exception("Список ответов ученика не соответствует списку проверки");
            int TotalPoints=0;
            byte CompareRes;
            for (int i = 0; i < UserAnswers.Count; i++)
            {
                CompareRes = Compare(UserAnswers[i].Answer, RigthAnswers[i]);
                if (CompareRes != 0)
                {
                    UserRigthAnswersNum++;
                    TotalPoints += CompareRes;
                    UserAnswers[i].Mark = CompareRes.ToString();

                    if (Markers != null)
                        foreach (var j in Markers)
                            if ((UserAnswers[i].Tag ?? "") == j.Tag)
                                j.Num++;
                }
            }
            return TotalPoints;
        }
       
        /// <summary>
        /// Оценка для задач на сравнение с текстном
        /// </summary>
        /// <param name="UserAnswer"></param>
        /// <param name="RightAnswers"></param>
        /// <returns></returns>
        static byte OboshenieMark(string UserAnswer, string RightAnswers)
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

        /// <summary>
        /// Производит анализ теста ШТУР.
        /// </summary>
        /// <param name="PupList">Список тестируемых.</param>
        /// <param name="ReCheck">Указывает на необходимость принудительно пересчитать все тесты типа ШТУР у ученика</param>
        public static void ShcoolCognitiveActivityTestAnalysis(List<Pupil> PupList,bool ReCheck)
        {
            foreach (var i in PupList)
            {
                foreach (var j in i.DoneTest)
                {
                    if ((!ReCheck && j.MarkForTest != null) || (j.Type != "SHTURA" && j.Type != "SHTURB") || j.Tasks.Count != 8) continue;

                    int Gum = 0, Math = 0, Nature = 0,/////////Гуманитарный , математический , Естественно-научный; 
                      Analogy = 0, Classification = 0, Oboshenie = 0, Knowledge = 0, NumberLines = 0, Space = 0;
                    bool IsA = j.Type == "SHTURA" ? true : false;
                    float PKnowledge, PAnalogy, PClassification, POboshenie, PNumberLines, PSpace, PersentOfTestComplete;
                    List<Marker> Markers = new List<Marker>() { new Marker() { Tag = "Gum"}, new Marker() { Tag = "Math" } , new Marker() { Tag = "Nature" } };

                    try
                    {
                        Func<string, string, byte> Compare = (string User, string Rigth) => { return (byte)(((User ?? "") == Rigth) ? 1 : 0); };

                        CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Knowledge1", $"A={IsA}"), j.Tasks[0].Questions, ref Knowledge, Compare);
                        CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Knowledge2", $"A={IsA}"), j.Tasks[1].Questions, ref Knowledge, Compare);
                        PKnowledge = (float)System.Math.Round((double)(Knowledge / 40), 3) * 100;

                        PAnalogy = CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Analogy", $"A={IsA}"), j.Tasks[2].Questions, ref Analogy, Compare, Markers)/ j.Tasks[2].Questions.Count * 100;
                        PClassification = CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Classification", $"A={IsA}"), j.Tasks[3].Questions, ref Classification, Compare, Markers) / j.Tasks[3].Questions.Count * 100;
                        POboshenie = CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Knowledge", $"A={IsA}"), j.Tasks[4].Questions, ref Oboshenie, OboshenieMark, Markers) / j.Tasks[4].Questions.Count * 100;

                        PNumberLines = CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "NumberLines", $"A={IsA.ToString()}"), j.Tasks[5].Questions, ref NumberLines, Compare) / j.Tasks[5].Questions.Count * 100;
                        CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Space1", $"A={IsA}"), j.Tasks[6].Questions, ref Space, Compare);
                        CheckAnswers(GetRightAnswers("//Answers//Answers.accdb", "Space2", $"A={IsA}"), j.Tasks[7].Questions, ref Space, Compare);
                        PSpace = (float)System.Math.Round((double)(Space / 10), 3) * 100;


                    }
                    catch { j.MarkForTest = "Не удалось проверить корректность ответов"; continue; }

                    
                    PersentOfTestComplete = (float)System.Math.Round((double)((Knowledge + Analogy + Classification + Oboshenie + NumberLines + Space) / 148), 3) * 100;
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

                    j.MarkForTest = $"Обший процент выполнения - {PersentOfTestComplete}%;" +
                        $"Уровень выполнения - {Level};Общая осведомлённость - {System.Math.Round((Knowledge / 40.0), 3) * 100}%;Аналогии - {System.Math.Round((Analogy / 25.0), 3) * 100}%;" +
                        $"Классификации - {System.Math.Round((Classification / 20.0), 3) * 100}%;Обобшения - {System.Math.Round((Oboshenie / 38.0), 3) * 100}%;Обшественно-гуманитарный цикл - {System.Math.Round((Gum / 33.0), 3) * 100}%;" +
                        $"Естственно-научный цикл - {System.Math.Round((Nature / 31.0), 3) * 100}%;Физико-математический цикл - {System.Math.Round((Math / 34.0), 3) * 100}%;Числовые ряды - {System.Math.Round((NumberLines / 15.0), 3) * 100}%;" +
                        $"Пространственные представления - {System.Math.Round((Space / 10.0), 3) * 100}%";

                }
            }
        }
    }
}
