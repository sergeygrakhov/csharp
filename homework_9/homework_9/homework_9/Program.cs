using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_9
{
    class Program
    {
        public static void Main(string[] args)
        {
            Language _language = SimpleChatBot.LanguageDetect();
            SimpleChatBot _bot = SimpleChatBot.BotCreate(_language);
            _bot.LetsTalk();
        }
    }
    enum Language
    {
        Russian,
        Ukrainian,
        English
    }
    abstract class SimpleChatBot
    {
        protected abstract void SayHello();
        protected abstract void SayNotUnderstand();
        protected abstract void SayHowAreYou();
        protected abstract void SayGoodBye();
        protected abstract void SaySomething();
        public static Language LanguageDetect()
        {
            String[] _helloRussian = new String[] { "привет", "здравствуйте", "приветствую", "добрый день", "хай", "здарова", "приветулики" };
            String[] _helloUkrainian = new String[] { "привіт", "доброго дня", "вітаю", "здоровеньки були", "добрий день" };
            String[] _helloEnglish = new String[] { "hello", "hi", "good morning", "greetings" };
            Boolean _languageDetect = false;
            Language _langId = default(Language);
            Console.Clear();
            Console.WriteLine("Приветствуем вас! Поздоровайтесь с ЧатБотом");
            Console.WriteLine("Вітаємо вас! Привітайтеся з ЧатБотом");
            Console.WriteLine("Welcome! Say hello to ChatBot");
            while (!_languageDetect)
            {
                String _stringHello = Console.ReadLine();
                _stringHello = _stringHello.ToLower();
                for (int i = 0; i < _helloRussian.Length; i++)
                {
                    if (_stringHello == _helloRussian[i])
                    {
                        _langId = Language.Russian;
                        _languageDetect = true;
                        break;
                    }
                }
                for (int i = 0; i < _helloUkrainian.Length; i++)
                {
                    if (_stringHello == _helloUkrainian[i])
                    {
                        _langId = Language.Ukrainian;
                        _languageDetect = true;
                        break;
                    }
                }
                for (int i = 0; i < _helloEnglish.Length; i++)
                {
                    if (_stringHello == _helloEnglish[i])
                    {
                        _langId = Language.English;
                        _languageDetect = true;
                        break;
                    }
                }
                if (!_languageDetect)
                {
                    Console.WriteLine("Не могу определить язык!");
                    Console.WriteLine("Не можу визначити мову!");
                    Console.WriteLine("Unable to detect your language!");
                }
            }
            return _langId;
        }
        public static SimpleChatBot BotCreate(Language _langArg)
        {
            SimpleChatBot _tempBot = null;
            switch (_langArg)
            {
                case Language.Russian:
                    _tempBot = new RussianBot();
                    break;
                case Language.Ukrainian:
                    _tempBot = new UkrainianBot();
                    break;
                case Language.English:
                    _tempBot = new EnglishBot();
                    break;
            }
            return _tempBot;
        }
        public abstract void LetsTalk();
    }
    class RussianBot : SimpleChatBot
    {
        private String[] _howAreYouQuestion = new String[] { "как дела?", "как твои дела?", "как сам?", "как настроение?" };
        private String[] _whatIsTheWeather = new String[] { "как погодка?", "какая погода?", "как тебе погода?", "что там с погодой?" };
        private String[] _goodByeSentence = new String[] { "пока", "до свидания", "прощай", "до новых встреч" };
        public override void LetsTalk()
        {
            Boolean _flagExit = false;
            this.SayHello();
            while (!_flagExit)
            {
                Boolean _userInputFind = false;
                while (!_userInputFind)
                {
                    String _userInput = Console.ReadLine();
                    _userInput = _userInput.ToLower();
                    for (int i = 0; i < this._howAreYouQuestion.Length; i++)
                    {
                        if (_userInput == this._howAreYouQuestion[i])
                        {
                            this.SayHowAreYou();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._whatIsTheWeather.Length; i++)
                    {
                        if (_userInput == this._whatIsTheWeather[i])
                        {
                            this.SaySomething();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._goodByeSentence.Length; i++)
                    {
                        if (_userInput == this._goodByeSentence[i])
                        {
                            this.SayGoodBye();
                            _userInputFind = true;
                            _flagExit = true;
                            break;
                        }

                    }
                    if (!_userInputFind)
                    {
                        this.SayNotUnderstand();
                    }
                }
            }
        }
        protected override void SayHello()
        {
            Console.WriteLine("Привет!");
        }
        protected override void SayNotUnderstand()
        {
            Console.WriteLine("Не понимаю");
        }
        protected override void SayHowAreYou()
        {
            Console.WriteLine("Все хорошо!");
        }
        protected override void SayGoodBye()
        {
            Console.WriteLine("До свидания!");
            Console.WriteLine("Для завершения нажмите любую клавишу...");
            Console.ReadKey();
        }
        protected override void SaySomething()
        {
            Console.WriteLine("Сегодня хорошая погода");
        }
    }
    class UkrainianBot : SimpleChatBot
    {
        private String[] _howAreYouQuestion = new String[] { "як справи?", "як діла?", "як себе почуваєте?" };
        private String[] _whatIsTheWeather = new String[] { "яка погода?", "як погодка?", "як тобі погода?", "що там з погодою?" };
        private String[] _goodByeSentence = new String[] { "до зустрічі", "до побачення", "прощавайте", "до нових зустрічей" };
        public override void LetsTalk()
        {
            Boolean _flagExit = false;
            this.SayHello();
            while (!_flagExit)
            {
                Boolean _userInputFind = false;
                while (!_userInputFind)
                {
                    String _userInput = Console.ReadLine();
                    _userInput = _userInput.ToLower();
                    for (int i = 0; i < this._howAreYouQuestion.Length; i++)
                    {
                        if (_userInput == this._howAreYouQuestion[i])
                        {
                            this.SayHowAreYou();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._whatIsTheWeather.Length; i++)
                    {
                        if (_userInput == this._whatIsTheWeather[i])
                        {
                            this.SaySomething();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._goodByeSentence.Length; i++)
                    {
                        if (_userInput == this._goodByeSentence[i])
                        {
                            this.SayGoodBye();
                            _userInputFind = true;
                            _flagExit = true;
                            break;
                        }

                    }
                    if (!_userInputFind)
                    {
                        this.SayNotUnderstand();
                    }
                }
            }
        }

        protected override void SayHello()
        {
            Console.WriteLine("Привіт!");
        }
        protected override void SayNotUnderstand()
        {
            Console.WriteLine("Не розумію!");
        }
        protected override void SayHowAreYou()
        {
            Console.WriteLine("Все добре!");
        }
        protected override void SayGoodBye()
        {
            Console.WriteLine("До побачення!");
            Console.WriteLine("Для завершення натисніть будь-яку кловішу...");
            Console.ReadKey();
        }
        protected override void SaySomething()
        {
            Console.WriteLine("Сьогодні гарна погода");
        }
    }
    class EnglishBot : SimpleChatBot
    {
        private String[] _howAreYouQuestion = new String[] { "how are you?", "how are you doing?" };
        private String[] _whatIsTheWeather = new String[] { "how is the weather?", "what is the weather?", "what do you think of the weather?", "what is up with the weather?" };
        private String[] _goodByeSentence = new String[] { "good bye", "see you later", "bye bye" };
        public override void LetsTalk()
        {
            Boolean _flagExit = false;
            this.SayHello();
            while (!_flagExit)
            {
                Boolean _userInputFind = false;
                while (!_userInputFind)
                {
                    String _userInput = Console.ReadLine();
                    _userInput = _userInput.ToLower();
                    for (int i = 0; i < this._howAreYouQuestion.Length; i++)
                    {
                        if (_userInput == this._howAreYouQuestion[i])
                        {
                            this.SayHowAreYou();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._whatIsTheWeather.Length; i++)
                    {
                        if (_userInput == this._whatIsTheWeather[i])
                        {
                            this.SaySomething();
                            _userInputFind = true;
                            break;
                        }

                    }
                    for (int i = 0; i < this._goodByeSentence.Length; i++)
                    {
                        if (_userInput == this._goodByeSentence[i])
                        {
                            this.SayGoodBye();
                            _userInputFind = true;
                            _flagExit = true;
                            break;
                        }

                    }
                    if (!_userInputFind)
                    {
                        this.SayNotUnderstand();
                    }
                }
            }
        }
        protected override void SayHello()
        {
            Console.WriteLine("Hi!");
        }
        protected override void SayNotUnderstand()
        {
            Console.WriteLine("Do not understand");
        }
        protected override void SayHowAreYou()
        {
            Console.WriteLine("Everything is fine");
        }
        protected override void SayGoodBye()
        {
            Console.WriteLine("Good bye");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        protected override void SaySomething()
        {
            Console.WriteLine("It's a good weather today");
        }
    }
}
