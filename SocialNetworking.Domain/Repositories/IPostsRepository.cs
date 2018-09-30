using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Repositories
{
    public interface IPostsRepository
    {
        IWallData Read(string user);
        void Post(IWallData wallData);
    }
}
