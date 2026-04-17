using DemoMongoDb.GrpcClient.Protos;
using Grpc.Net.Client;

namespace DemoMongoDb.GrpcClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Tao dia chi cua gRPC Service
            var address = "http://localhost:5002";

            // Tao chanel
            var chanel = GrpcChannel.ForAddress(address);

            // Goi Service
            var client = new MenuService.MenuServiceClient(chanel);

            var newClient = new NewsService.NewsServiceClient(chanel);

            try
            {
                // Get all menu
                Console.WriteLine("=======MENU=======");
                var allMenus = await client.GetAllMenusAsync(new GetAllMenusRequest());

                foreach (var menu in allMenus.Items)
                {
                    Console.WriteLine($"{menu.Id} - {menu.Name}");
                }
                Console.WriteLine("==================");

                // Get all news
                Console.WriteLine("=======NEWS=======");

                var allNews = await newClient.GetAllNewsAsync(new GetAllNewsRequest());
                foreach (var news in allNews.Items)
                {
                    Console.WriteLine($"{news.Id} - {news.Title}");
                }
                Console.WriteLine("==================");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
