using FoodDeliveryAPI.Hubs;
using FoodDeliveryAPI.Repositories;
using Microsoft.AspNetCore.SignalR;

public class DailyNotificationService : BackgroundService
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IServiceProvider _services;

    public DailyNotificationService(IHubContext<NotificationHub> hubContext, IServiceProvider services)
    {
        _hubContext = hubContext;
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var target = DateTime.Today.AddHours(22).AddMinutes(38); // 10:14 PM today


            if (now > target)
                target = target.AddDays(1);

            var delay = target - now;
            await Task.Delay(delay, stoppingToken);

            using (var scope = _services.CreateScope())
            {
                var notificationRepo = scope.ServiceProvider.GetRequiredService<INotificationRepository>();
                var users = await notificationRepo.GetAllUsers();

                foreach (var user in users)
                {
                    var message = $"Hello {user.Name}, it's 5 PM! 🎉";

                    // Send notification (currently broadcast to all connected clients)
                    await _hubContext.Clients.All.SendAsync("ReceiveNotification", message, cancellationToken: stoppingToken);

                    // Log notification in DB
                    await notificationRepo.LogNotification(user.UserId, message);
                }
            }
        }
    }
}
