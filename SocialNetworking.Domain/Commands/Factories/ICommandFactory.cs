using SocialNetworking.Domain.Commands.Interfaces;

namespace SocialNetworking.Domain.Commands.Factories
{
    public interface ICommandFactory
    {
        ICommand GenerateCommand(string commandText);
    }
}
