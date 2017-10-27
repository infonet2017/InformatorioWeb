using Informatorio.WebInformatorio.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Informatorio.WebInformatorio.Business
{
    public class PostManager
    {
        //private InfoDbContext InfoDbContext { get; set; }
        InfoDbContext InfoDb = new InfoDbContext();

        //save post
        //delete post
        //add post to module
        //modify post 
        //search

        public void SavePost(int Id, string Title, string Description, string Teacher, DateTime Day)
        {
            var posts = new Post(Id, Title, Description, Teacher, Day);
            InfoDb.Posts.Add(posts);
            //Para mi aca iria un return post y se haria el publish y el save de una
        }

        public string PublishPost() // esto no se si esta bien
        {
            if (InfoDb.Posts == null)
            {
                throw new Exception();
            }
            else
            {
                var item = InfoDb.Posts[InfoDb.Posts.Count - 1]; // muestra la ultima publicación
                var text = "";
                return ($"{text} {item.Title}\n {item.DateTime.ToString()} \n{item.Teacher}\n {item.Description}\n");
            }
        }

        public string PublishWall()// Muestra todos los post // Ver muro
        {
            var text = "";

            if (InfoDb.Posts == null)
            {
                throw new Exception();
            }
            else
            {
                foreach (var item in InfoDb.Posts)
                {
                    
                    text = text + ($"{item.Id}\n {item.Title}\n {item.DateTime.ToString()} \n{item.Teacher}\n {item.Description}\n\n\n");
                }
                return text;
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

        public Boolean DeletePost(int idPost)
        {
            bool deleted = false;
            try
            { 

                foreach (Post currentPost in InfoDb.Posts) //cycle through all posts searching for the entry id
                {
                    if (currentPost.Id == idPost) // found the post :)
                    {
                        InfoDb.Posts.Remove(currentPost); //remove that
                        deleted = true;
                        break;
                    }
                }

                if (deleted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //throw new Exception();
                return false;
            }

        }
    }
}
