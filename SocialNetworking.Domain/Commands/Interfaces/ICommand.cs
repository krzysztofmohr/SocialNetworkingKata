using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Commands.Interfaces
{
    public interface ICommand
    {
        IWallData Process(IPostsRepository postsRepository);
    }
}
