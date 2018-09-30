using System;

namespace SocialNetworking.Domain.Display.Interfaces
{
    public interface IPostTimeFormatter
    {
        string FormatPostTime(DateTime postTimestamp);
    }
}
