using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var obras = await GetObrasAsync();
            foreach (var item in obras)
            {
                Console.WriteLine(item.codigoUnico);
            }
            Console.WriteLine("Hugo Torrico");
            Console.Read();
        }

        private static async Task<List<Obras>> GetObrasAsync()
        {

            HttpClient client = new HttpClient();
            var obras = new List<Obras>();
            var urlBase = "http://sitra.emape.gob.pe:8082";
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api/expedientes/obtener_proyectos/0");

            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                obras = JsonConvert.DeserializeObject<List<Obras>>(result);
               
            }
            return obras;
        }

        private static async Task ShowObrasAsync()
        {

            HttpClient client = new HttpClient();
            var obras = new List<Obras>();
            var urlBase = "http://sitra.emape.gob.pe:8082";
            client.BaseAddress = new Uri(urlBase);
            var url = string.Concat(urlBase, "/api/expedientes/obtener_proyectos/0");

            var response = client.GetAsync(url).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                obras = JsonConvert.DeserializeObject<List<Obras>>(result);

            }
            foreach (var item in obras)
            {
                Console.WriteLine(item.codigoUnico);
            }

        }

    }
}
