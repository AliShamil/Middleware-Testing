using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace MyFirstAmazingWebApi.Middlewares;

public class TimeRestrictionMiddleware
{
    private readonly RequestDelegate _next;

    public TimeRestrictionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var currentTime = DateTime.Now.TimeOfDay;
        var startTime = new TimeSpan(12, 0, 0);
        var endTime = new TimeSpan(18, 0, 0);

        if (currentTime >= startTime && currentTime <= endTime)
        {
            System.Console.WriteLine("You entered at correct time!");
            await _next(context);
            System.Console.WriteLine("42");
        }
        else
        {
            context.Response.StatusCode = 403;
            System.Console.WriteLine($"You cannot make requests at this time! Required:({startTime.ToString(@"hh\:mm")} - {endTime.ToString(@"hh\:mm")})");
        }
    }

}
