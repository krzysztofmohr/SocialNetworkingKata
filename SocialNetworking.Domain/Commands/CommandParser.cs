using System.Collections.Generic;
using System.Linq;
using SocialNetworking.Domain.Commands.Factories;
using SocialNetworking.Domain.Commands.Interfaces;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Commands
{
    public class CommandParser : ICommandParser
    {
        private readonly IEnumerable<ICommandFactory> _commandFactories;
        private readonly IPostsRepository _postsRepository;

        public CommandParser(IEnumerable<ICommandFactory> commandFactories, IPostsRepository postsRepository)
        {
            _commandFactories = commandFactories;
            _postsRepository = postsRepository;
        }

        public IWallData Parse(string commandText)
        {
            return (from commandFactory in _commandFactories select commandFactory.GenerateCommand(commandText) into command where command != null select command.Process(_postsRepository)).FirstOrDefault();
        }
    }
}