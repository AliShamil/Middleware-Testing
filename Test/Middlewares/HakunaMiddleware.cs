using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstAmazingWebApi.Middlewares;

public class HakunaMiddleware
{
    RequestDelegate _next;

    public HakunaMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        System.Console.WriteLine("Hakuna Matata");
        await _next.Invoke(context);
        System.Console.WriteLine("Good Bye, Hakuna!!!");
    }
}
