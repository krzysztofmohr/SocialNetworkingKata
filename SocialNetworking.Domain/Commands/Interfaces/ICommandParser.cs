using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Commands.Interfaces
{
    public interface ICommandParser
    {
        IWallData Parse(string commandText);
    }
}