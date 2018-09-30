using SocialNetworking.Domain.Commands.Interfaces;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Commands
{
    public class ReadCommand : ICommand
    {
        private readonly string _user;        

        public ReadCommand(string user)
        {
            _user = user;            
        }
        public IWallData Process(IPostsRepository postsRepository)
        {
            return postsRepository.Read(_user);
        }
    }
}
