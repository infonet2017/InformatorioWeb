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
            pm.publishPost("nombre", DateTime.Today, "nombre del user que lo publico");
            List<Post> allPosts = pm.getAllPosts();
            foreach (var item in allPosts)
            {
                Console.WriteLine(item.Name);
            }
            
        }
    }
}
