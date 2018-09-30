using SocialNetworking.Domain.Commands.Interfaces;
using SocialNetworking.Domain.Display.Interfaces;

namespace SocialNetworking.Domain.Services
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly ICommandParser _commandParser;
        private readonly IDisplayResultService _displayResultService;

        public SocialNetworkService(ICommandParser commandParser, IDisplayResultService displayResultService)
        {            
            _commandParser = commandParser;
            _displayResultService = displayResultService;
        }

        public void EnterCommand(string commandText)
        {            
            var wallData = _commandParser.Parse(commandText);            
            if (wallData != null)
            {
                _displayResultService.Show(wallData);
            }
        }
    }
}
