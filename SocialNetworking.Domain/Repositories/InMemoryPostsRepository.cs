using System.Collections.Concurrent;
using System.Collections.Generic;
using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Repositories
{
    public class InMemoryPostsRepository : IPostsRepository
    {
        private readonly IDictionary<string, IWallData> _wallsData = new ConcurrentDictionary<string, IWallData>();       

        public IWallData Read(string user)
        {
            return _wallsData.ContainsKey(user) ? _wallsData[user] : new WallData();
        }

        public void Post(IWallData wallData)
        {
            if (_wallsData.ContainsKey(wallData.User))
            {
                _wallsData[wallData.User].Posts.AddRange(wallData.Posts);                
            }
            else
            {
                _wallsData.Add(wallData.User, wallData);
            }            
        }
    }
}
