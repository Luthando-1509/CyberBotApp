using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CyberBotApp.Services
{
    public class ChatbotService
    {
        private string _userName;
        private Dictionary<string, string> _responses;

        public ChatbotService(string userName)
        {
            _userName = userName;
            _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "hello", $"Hello, {_userName}! How can I help you today?" },
                { "hi", $"Hi, {_userName}! What's on your mind regarding cybersecurity?" },
                { "how are you", "I'm a bot, so I don't have feelings, but I'm ready to assist you!" },
                { "what's your purpose", "My purpose is to educate you about cybersecurity and help you stay safe online." },
                { "what can i ask you about", "You can ask me about password safety, phishing, safe browsing, and other general cybersecurity tips." },
                { "password safety", "Strong passwords are long, complex, and unique. Use a combination of uppercase and lowercase letters, numbers, and symbols. Never reuse passwords!" },
                { "phishing", "Phishing is a cyberattack that uses disguised email, text message or telephone call as a weapon. The goal is to trick the recipient into believing that the message is something they want or need, such as a request from their bank, or a note from someone in their company." },
                { "safe browsing", "Always check for 'https://' in the URL, be cautious of pop-ups, and avoid clicking suspicious links. Keep your browser and operating system updated." },
                { "exit", "Goodbye! Stay safe online!" }
            };
        }

        public void StartConversation()
        {
            string userInput;
            do
            {
                ConsoleUI.UserPrompt($"{_userName}> ");
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleUI.BotResponse("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                string response = GetResponse(userInput);
                ConsoleUI.BotResponse(response);

            } while (!userInput.Equals("exit", StringComparison.OrdinalIgnoreCase));
        }

        private string GetResponse(string input)
        {
            foreach (var entry in _responses)
            {
                if (input.ToLower().Contains(entry.Key.ToLower()))
                {
                    return entry.Value;
                }
            }
            return "I didn't quite understand that. Could you rephrase?";
        }
    }
}
