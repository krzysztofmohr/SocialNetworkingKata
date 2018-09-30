using System.Collections.Generic;

namespace SocialNetworking.Domain.Entities
{
    public class WallData : IWallData
    {
        public string User { get; set; }
        public List<Post> Posts { get; set; }
    }
}
