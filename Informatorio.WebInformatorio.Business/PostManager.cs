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

        public Post PublishPost() // esto no se si esta bien
        {
            if (InfoDb.Posts == null)
            {
                throw new Exception();
            }
            else
            {
                var item = InfoDb.Posts[InfoDb.Posts.Count - 1]; // muestra la ultima publicación
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

        public void DeletePost(int idPost)
        {
            bool deleted = false;
            try
            {
                var pm = new PostManager();

                //<remove>
                for (int i = 0; i < 8; i++) //this "for" is only to verify that the posts are added and only the number 6 is deleted.
                {
                    pm.SavePost(i, "title", "this is a publication", "theacher", DateTime.Today);
                    Console.WriteLine(pm.PublishPost().Id + " " + pm.PublishPost().Description);
                } //if run ok, these 7 lines must removed 
                //</remove>

                List<Post> allPosts = pm.getAllPosts(); //charge all post to search "the post" to remove

                foreach (Post currentPost in allPosts) //cycle through all posts searching for the entry id
                {
                    if (currentPost.Id == idPost) // found the post :)
                    {
                        allPosts.Remove(currentPost); //remove that
                        deleted = true;
                        break;
                    }
                }

                if (deleted)
                {
                    Console.WriteLine("The post with ID " + idPost + " has been successfully removed");
                    //<remove>
                    foreach (var item in allPosts)
                    {
                        Console.WriteLine(item.Id + " " + item.Description);

                    }
                    //</remove>
                }
                else
                {
                    Console.WriteLine("Doesn't possible eliminate the post");
                }
            }
            catch (Exception)
            {
                //throw new Exception();
                Console.WriteLine("You have a problem");
            }

        }
    }
}
