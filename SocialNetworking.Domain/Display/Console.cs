using SocialNetworking.Domain.Display.Interfaces;
using static System.Console;

namespace SocialNetworking.Domain.Display
{
    public class Console : IConsole
    {
        public void PrintLine(string line)
        {
            WriteLine(line);
        }
    }
}