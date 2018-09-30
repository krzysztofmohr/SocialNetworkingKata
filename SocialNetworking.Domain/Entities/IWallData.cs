using System.Collections.Generic;

namespace SocialNetworking.Domain.Entities
{
    public interface IWallData
    {
        string User { get; set; }
        List<Post> Posts { get; set; }
    }
}
