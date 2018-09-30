using System;
using SocialNetworking.Domain.Display.Interfaces;

namespace SocialNetworking.Domain.Display
{
    public class PostTimeFormatter : IPostTimeFormatter
    {
        public string FormatPostTime(DateTime postTimestamp)
        {
            var result = DateTime.Now.Subtract(postTimestamp);

            if (result.TotalMinutes < 1)
            {
                return $"{(int) result.TotalSeconds} seconds ago";
            }

            if (result.TotalHours < 1)
            {
                return $"{(int)result.TotalMinutes} minutes ago";                
            }

            return result.TotalDays < 1 ? $"{(int)result.TotalHours} hours ago" : $"{(int)result.TotalDays} days ago";
        }
    }
}