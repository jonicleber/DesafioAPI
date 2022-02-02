using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DesafioAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {


            using (masterContext contatosFavoritos = new masterContext())
            {
                contatosFavoritos.Add(new ContatosFavoritos { ICodCooperado = 1, SNomeContatoFavorito = $@"jão", ICodPix = 1, SChavePix = "34999122150" });

                var contador = contatosFavoritos.SaveChanges();

                Console.WriteLine("{0} registros salvos no banco de dados : ", contador);

                CreateWebHostBuilder(args).Build().Run();
                Console.ReadKey();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();



    }
}
