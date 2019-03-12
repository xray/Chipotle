using System;

namespace xray.Chipotle
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = 5000;
            var server = new Chorizo.Chorizo(port);
            Console.WriteLine($"Starting to listen on port {port}");
            server.Start();
        }
    }
}
