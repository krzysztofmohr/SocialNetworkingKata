using System.Text.RegularExpressions;
using SocialNetworking.Domain.Commands.Interfaces;

namespace SocialNetworking.Domain.Commands.Factories
{
    public class ReadCommandFactory : ICommandFactory
    {
        private readonly Regex _readCommand = new Regex(@"^(\w+)$");
        
        public ICommand GenerateCommand(string commandText)
        {
            if (!_readCommand.IsMatch(commandText)) return null;

            var matches = _readCommand.Matches(commandText);
            var user = matches[0].Groups[1].Value;
            return new ReadCommand(user);
        }
    }
}
