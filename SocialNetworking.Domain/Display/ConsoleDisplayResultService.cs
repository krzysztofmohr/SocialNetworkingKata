using System.Linq;
using SocialNetworking.Domain.Display.Interfaces;
using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Display
{
    public class ConsoleDisplayResultService : IDisplayResultService
    {
        private readonly IPostTimeFormatter _postTimeFormatter;
        private readonly IConsole _console;

        public ConsoleDisplayResultService(IPostTimeFormatter postTimeFormatter, IConsole console)
        {
            _postTimeFormatter = postTimeFormatter;
            _console = console;
        }

        public void Show(IWallData wallData)
        {
            wallData.Posts.OrderByDescending(p => p.Timestamp).ToList()
                .ForEach(p => _console.PrintLine($"{p.Text} ({_postTimeFormatter.FormatPostTime(p.Timestamp)})"));
        }
    }
}