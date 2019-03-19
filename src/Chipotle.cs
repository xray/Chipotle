using System;
using Chorizo.HTTP.Exchange;
using Chorizo.HTTP.ReqProcessor;

namespace xray.Chipotle
{
    class Program
    {
        static void Main(string[] args)
        {
            var port = 5000;
            var server = new Chorizo.App(port, routes: new Routes()
                .Get("/simple_get", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK")
                        .AddHeader("Server", "Chorizo");
                })
                .Post("/echo_body", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK", req.Body)
                        .AddHeader("Server", "Chorizo");
                })
                .Get("/method_options", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK")
                        .AddHeader("Server", "Chprizo");
                })
                .Get("/method_options2", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK")
                        .AddHeader("Server", "Chorizo");
                })
                .Put("/method_options2", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK")
                        .AddHeader("Server", "Chorizo");
                })
                .Post("/method_options2", req =>
                {
                    return new Response("HTTP/1.1", 200, "OK")
                        .AddHeader("Server", "Chorizo");
                })
                .Get("/redirect", req =>
                {
                    return new Response("HTTP/1.1", 301, "Moved Permanently")
                        .AddHeader("Location", "http://localhost:5000/simple_get");
                })
                .Head("/get_with_body", req =>
                {
                    return new Response("HTTP/1.1", 200, "Method Not Allowed")
                        .AddHeader("Server", "Chorizo");
                })
            );

            Console.WriteLine($"Starting to listen on port {port}");
            server.Start();
        }
    }
}
