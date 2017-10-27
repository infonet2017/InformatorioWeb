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

            Console.WriteLine("Add 7 post");
            for (int i = 0; i < 8; i++)
            {
                pm.SavePost(i,"title", "this is a publication", "theacher", DateTime.Today);
                Console.WriteLine($"Creating the post Number {i}");
               
            }


            Console.WriteLine("Showing the Post Wall");

            Console.WriteLine(pm.PublishWall());


            Console.WriteLine("Testing the delete module");
            Console.WriteLine($"Ingrese ID del post a eliminar");
            Int32.TryParse(Console.ReadLine(), out var id);
            pm.DeletePost(id);

            Console.WriteLine(pm.PublishWall());

            Console.ReadKey();
        }
    }
}
