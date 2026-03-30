using System;
using System.IO;
using System.Threading;
using CyberBotApp.Services;

namespace CyberBotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            // Display ASCII Art
            ConsoleUI.DisplayAsciiArt("Assets/logo.txt");

            // Play Voice Greeting (Windows-specific)
            if (OperatingSystem.IsWindows())
            {
                ConsoleUI.PlayVoiceGreeting("Assets/greeting.wav");
            }
            else
            {
                Console.WriteLine("\nVoice greeting is only available on Windows.");
            }

            Thread.Sleep(2000); // Pause to allow user to hear the greeting
            Console.Clear();

            // Display welcome message and get user name
            ConsoleUI.DisplayAsciiArt("Assets/logo.txt");
            ConsoleUI.DisplayWelcomeMessage();
            Console.Write("\n> What is your name? ");
            string userName = Console.ReadLine();
            userName = string.IsNullOrWhiteSpace(userName) ? "User" : userName;

            Console.Clear();
            ConsoleUI.DisplayAsciiArt("Assets/logo.txt");
            ConsoleUI.DisplayPersonalizedWelcome(userName);

            // Start the chatbot conversation
            ChatbotService chatbot = new ChatbotService(userName);
            chatbot.StartConversation();
        }
    }
}
