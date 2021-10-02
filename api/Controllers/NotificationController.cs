using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers {
  [ApiController, Route("notifications")]
  public class NotificationController : ControllerBase {

    private readonly NotificationService _notificationService;
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(NotificationService notificationService, ILogger<NotificationController> logger) {
      _notificationService = notificationService;
      _logger = logger;
    }

    [HttpPost, Route("")]
    public IActionResult SendNotification([FromBody]Notification notification) {
      var result = _notificationService.SendNotification(notification);
      
      return Ok(result);
    }
  }
}