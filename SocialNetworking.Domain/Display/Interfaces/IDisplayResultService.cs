using SocialNetworking.Domain.Entities;

namespace SocialNetworking.Domain.Display.Interfaces
{
    public interface IDisplayResultService
    {
        void Show(IWallData wall);
    }
}