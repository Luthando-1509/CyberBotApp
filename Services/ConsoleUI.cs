using System;
using System.IO;
using System.Media;
using System.Threading;

namespace CyberBotApp.Services
{
    public static class ConsoleUI
    {
        public static void DisplayAsciiArt(string filePath)
        {
            try
            {
                string asciiArt = File.ReadAllText(filePath);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(asciiArt);
                Console.ResetColor();
                Thread.Sleep(1000);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ASCII art file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying ASCII art: {ex.Message}");
            }
        }

        public static void PlayVoiceGreeting(string filePath)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.PlaySync();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Voice greeting file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing voice greeting: {ex.Message}");
            }
        }

        public static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================================================================");
            Console.WriteLine("  Welcome to the Cybersecurity Awareness Bot!                    ");
            Console.WriteLine("  I'm here to help you stay safe online.                       ");
            Console.WriteLine("================================================================");
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public static void DisplayPersonalizedWelcome(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================================================================");
            Console.WriteLine($"  Hello, {userName}! How can I assist you with cybersecurity today?");
            Console.WriteLine("================================================================");
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        public static void BotResponse(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Bot: ");
            TypewriterEffect(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void UserPrompt(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{prompt} ");
            Console.ResetColor();
        }

        public static void TypewriterEffect(string message, int delay = 30)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
        }
    }
}
