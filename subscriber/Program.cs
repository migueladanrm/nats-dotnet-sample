using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NATS.Client;
using NATS.Client.Rx;
using NATS.Client.Rx.Ops;

namespace subscriber {
  class Program {
    private const string NATS_ENDPOINTS = "nats://localhost:4444";
    private const string NATS_SUBJECT = "hello";

    static void Main(string[] args) {
      using (var connection = new ConnectionFactory().CreateConnection(NATS_ENDPOINTS)) {
        var messages = connection.Observe(NATS_SUBJECT)
                                 .Where(m => m.Data?.Any() == true)
                                 .Select(m => m.Data);

        messages.Subscribe(m => {
          var plainTextMessage = Encoding.UTF8.GetString(m);
          Console.WriteLine($"\n----- New message -----\n{plainTextMessage}");
        });

        Console.ReadKey();
      }
    }
  }
}
