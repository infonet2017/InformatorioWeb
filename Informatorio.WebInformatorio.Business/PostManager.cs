using Informatorio.WebInformatorio.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Informatorio.WebInformatorio.Business
{
    public class PostManager
    {
        private InfoDbContext InfoDbContext { get; set; }
        InfoDbContext InfoDb = new InfoDbContext();
        //save post
        public void SavePost(int Id,string Title, string Description, string Teacher, DateTime Day)
        {
            var posts = new Post(Id,Title, Description, Teacher, Day);
            InfoDb.Posts.Add(posts);
            //podria ser un Return posts y hacemos save y publisher de una
        }
        //delete post
        //add post to module
        //modify post 
        //search
        public Post PublishPost() // esto no se si esta bien
        {
            if (InfoDb.Posts == null)
            {
                throw new Exception();
            }
            else
            {
                
                var item = InfoDb.Posts[InfoDb.Posts.Count - 1];
                return item;
            }

        }
        
        public List<Post> getAllPosts()
        {
            if (InfoDb.Posts.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                return InfoDb.Posts;
            }
            
        }
    }
}
