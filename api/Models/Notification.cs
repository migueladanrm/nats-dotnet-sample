using System;

namespace api.Models {
  public class Notification {
    public string Id { get; set; }
    public string Channel { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}