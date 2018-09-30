using System.Text.RegularExpressions;
using SocialNetworking.Domain.Commands.Interfaces;

namespace SocialNetworking.Domain.Commands.Factories
{
    public class PostCommandFactory : ICommandFactory
    {
        private readonly Regex _postCommand = new Regex(@"^(.*) -> (.*)$");

        public ICommand GenerateCommand(string commandText)
        {
            if (!_postCommand.IsMatch(commandText)) return null;

            var matches = _postCommand.Matches(commandText);
            var user = matches[0].Groups[1].Value;
            var message = matches[0].Groups[2].Value;
            return new PostCommand(user, message);
        }
    }
}
