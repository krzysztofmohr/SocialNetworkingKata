using System;
using System.Collections.Generic;
using SocialNetworking.Domain.Commands.Interfaces;
using SocialNetworking.Domain.Entities;
using SocialNetworking.Domain.Repositories;

namespace SocialNetworking.Domain.Commands
{
    public class PostCommand : ICommand
    {
        private readonly string _user;
        private readonly string _message;

        public PostCommand(string user, string message)
        {
            _user = user;
            _message = message;            
        }

        public IWallData Process(IPostsRepository postsRepository)
        {
            postsRepository.Post(new WallData {Posts = new List<Post>{new Post{Text = _message, Timestamp = DateTime.Now}}, User = _user});
            return null;
        }
    }
}