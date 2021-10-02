using api.Models;
using NATS.Client;
using System.Text;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using api.Extensions;

namespace api.Services {
  public class NotificationService {
    private readonly IConnection _connection;
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(IConnection connection, ILogger<NotificationService> logger) {
      _connection = connection;
      _logger = logger;
    }

    public Notification SendNotification(Notification notification) {
      notification.Id = Guid.NewGuid().ToString();
      notification.CreatedAt = DateTime.Now;
      var stringJsonNotification = notification.Serialize();

      _connection.Publish(notification.Channel, Encoding.UTF8.GetBytes(stringJsonNotification));
      _logger.LogInformation($"Notification sent at {DateTime.Now.ToString("O")}");
      
      return notification;
    }
  }
}