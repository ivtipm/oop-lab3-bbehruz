using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Chat_Bot
{
    public class ChatBot : AbstractChatBot
    {
        static string userName; // имя пользователя
        string path; // путь к файлу с историей сообщений
        List<string> history = new List<string>(); // хранение истории

        //регулярные выражения
        List<Regex> regecies = new List<Regex>
        {
            new Regex(@"привет"),
            new Regex(@"(?:который час\??|сколько времени\??|время\??)"),
            new Regex(@"(?:какое сегодня число\??|число\??|дата\??)"),
            new Regex(@"как дела\??"),
            new Regex(@"(?:спасибо|благодарю)"),
            new Regex(@"(?:умножь(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:раздели(\s)?(\d+)(\s)?на(\s)?(\d+))"),
            new Regex(@"(?:сложи(\s)?(\d+)(\s)?и(\s)?(\d+))"),
            new Regex(@"(?:вычти(\s)?(\d+)(\s)?из(\s)?(\d+))"),
            new Regex(@"(?:курсы валют|курс)"),
            new Regex(@"погода"),
            new Regex(@"(?:пока|до свидания)")
        };

        Func<string, string> funcBuf; //буфер

        List<Func<string, string>> func = new List<Func<string, string>>
            {
                HelloBot,
                HowTime,
                HowDate,
                HowAreYou,
                ThankYou,
                MulPls,
                DivPls,
                PlusPls,
                SubPls,
                CurrencyRate,
                WeatherPls,
                GoodBye
            };

        public ChatBot()
        {

        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
        }
        public List<string> History
        {
            get
            {
                return history;
            }
        }

        static string HelloBot(string question)
        {
            return "Привет, " + userName + "!";
        }

        static string HowTime(string question)
        {
            return "Сейчас: " + DateTime.Now.ToString("HH:mm");
        }

        static string HowDate(string question)
        {
            return "Сегодня: " + DateTime.Now.ToString("dd.MM.yy");
        }

        static string HowAreYou(string question)
        {
            Random rnd = new Random();
            int value = rnd.Next();
            if (value % 2 == 0)
                return "В полном порядке. Иногда, правда, в случайном";
            else
            {
                return "Да что нам все о делах, да о делах! Давай следующий вопрос";
            }
        }

        static string ThankYou(string question)
        {
            return "Обращайся в любое время.";
        }

        static string MulPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ь') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 * num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        static string DivPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('и') + 1);
            string[] words = question.Split(new char[] { 'н', 'а' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                float num1 = Convert.ToInt32(words[0]);
                float num2 = Convert.ToInt32(words[1]);
                return (num1 / num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        static string PlusPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('ж') + 2);
            string[] words = question.Split(new char[] { 'и' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num1 + num2).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        static string SubPls(string question)
        {
            question = question.Replace(" ", "");
            question = question.Substring(question.LastIndexOf('т') + 2);
            string[] words = question.Split(new char[] { 'и', 'з' },
            StringSplitOptions.RemoveEmptyEntries);
            try
            {
                int num1 = Convert.ToInt32(words[0]);
                int num2 = Convert.ToInt32(words[1]);
                return (num2 - num1).ToString();
            }
            catch
            {
                return "Извините, я не понял ваш вопрос";
            }
        }

        static string CurrencyRate(string userQuestion)
        {
            List<CurrencyRate> tmp = CurrencyRates.GetExchangeRates();
            return "Доллар США: " + tmp.FindLast(s => s.CurrencyStringCode == "USD").ExchangeRate.ToString() +
                   "\r\n        Евро: " + tmp.FindLast(s => s.CurrencyStringCode == "EUR").ExchangeRate.ToString();
        }

        static string WeatherPls(string question)
        {
            String[] infoWeather = WeatherInfo.FindOutWeather();
            return "Погода в городе " + infoWeather[0] + " " + infoWeather[1] + " °C"
                + ". Ветер " + infoWeather[2] + " м/c";
        }

        static string GoodBye(string userQuestion)
        {
            Random rnd = new Random();
            int value = rnd.Next();
            if (value % 2 == 0)
                return "До свидания.";
            else
            {
                return "Успехов вам!";
            }
        }

        public void LoadHistory(string user)
        {
            userName = user;
            path = userName + ".txt"; // запись пути

            try
            {
                //попытка загрузки существующей базы
                history.AddRange(File.ReadAllLines(path, Encoding.GetEncoding(1251)));

                // Если файл был изменен не сегодня, то записываем новую дату
                // переписки
                if (File.GetLastWriteTime(path).ToString("dd.MM.yy") !=
                    DateTime.Now.ToString("dd.MM.yy"))
                {
                    String[] date = new String[] {"\n" + "Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy"+ "\n")};
                    AddToHistory(date);
                }
            }
            catch
            {
                // если файл не существует, создаем его
                File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
                // отмечаем дату начала переписки
                String[] date = new String[] {"Переписка от " +
                        DateTime.Now.ToString("dd.MM.yy") + "\n"};
                AddToHistory(date);

            }
        }

        public void AddToHistory(string[] answer)
        {
            history.AddRange(answer);
            File.WriteAllLines(path, history.ToArray(), Encoding.GetEncoding(1251));
        }

        // проверка сообщения от пользователя и возвращения ответа
        public override string Answer(string userQuestion)
        {
            userQuestion = userQuestion.ToLower(); // переводим в нижний регистр
            for (int i = 0; i < regecies.Count; i++)
            {
                if (regecies[i].IsMatch(userQuestion))
                {
                    funcBuf = func[i];
                    return funcBuf(userQuestion);
                }

            }
            return "Извините, я не понял ваш вопрос";
        }
    }
}
