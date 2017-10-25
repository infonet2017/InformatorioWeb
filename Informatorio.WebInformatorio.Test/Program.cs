using Informatorio.WebInformatorio.Business;
using Informatorio.WebInformatorio.Data;
using System;
using System.Collections.Generic;

namespace Informatorio.WebInformatorio.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pm = new PostManager();
            for (int i = 0; i < 8; i++)
            {
                pm.SavePost(i, "Titulaso", "esto es una publicacion loco", "profesor giraf", DateTime.Today);
                Console.WriteLine(pm.PublishPost().Description);
                Console.ReadLine();
                
                
            }
            pm.SavePost(1,"Titulaso", "esto es una publicacion loco", "profesor giraf", DateTime.Today);
            try
            {
                List<Post> allPosts = pm.getAllPosts();
                foreach (var item in allPosts)
                {
                    Console.WriteLine(item.Id + " " + item.Description);
                    
                }
            }
            catch (Exception)
            {

                Console.WriteLine("something wrong with your data. Are you sure you are not storing the same pokemon twice?");
                Console.ReadLine();
            }
            Console.ReadLine();
            /*List<Post> allPosts = pm.getAllPosts();
            foreach (var item in allPosts)
            {
                Console.WriteLine(item.Description);
                Console.ReadLine();
            }
            */

        }
    }
}
