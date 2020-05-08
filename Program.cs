using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FunnyMan
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Read or Write? R/W");
                string response = Console.ReadLine();
                if (response.ToLower() == "r")
                {
                    Console.WriteLine("Input Key.");
                    string key = Console.ReadLine();
                    string url = "http://heybarnes.com:5000/api?key=" + key + "&read=1";
                    await Program.ReadSite(url);
                }
                else if (response.ToLower() == "w")
                {
                    Console.WriteLine("Input Key.");
                    string key = Console.ReadLine();
                    Console.WriteLine("Input Value.");
                    string value = Console.ReadLine();
                    string url = "http://heybarnes.com:5000/api?key=" + key + "&value=" + value + "&read=0";
                    await Program.ReadSite(url);
                }
                Console.WriteLine("Press Enter To Continue...");
                Console.ReadLine();
            }
        }

        static async Task ReadSite(string url)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}
