using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var res = await Suma(3, 5);

            Console.WriteLine(res);

            var res2 = await Resta(3, 5);
            Console.WriteLine(res2);

            var resGet = GetBooks();

            Console.WriteLine(resGet.Result);


        }
        public static async Task<int> Suma(int i, int j)
        {
            var sumaRes = await Task.Run(() =>
            {
                return i + j;
            });

            return sumaRes;
        }

        public static async Task<int> Resta(int i, int j)
        {
            var restaRes = await Task.Run(() =>
            {
                return i - j;
            });


            return restaRes;
        }

        public static async Task<string> GetBooks()
        {
            var resultado = string.Empty;
            using (var http = new HttpClient())
            {

                resultado = await http.GetAsync("https://jsonplaceholder.typicode.com/posts/1").Result.Content.ReadAsStringAsync();

            }

            return resultado;
        }

    }
}
