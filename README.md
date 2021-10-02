# NATS on .NET

This demo shows how to communicate two applications using NATS.

## Running

To run this demo, you'll need to follow the next steps.

- You need a NATS instance endpoint, you can deploy a Docker image with the next instruction:

  ```bash
  docker run -d --name nats -p 4444:4444 nats -p 4444
  ```

- Run the **API** project, this will start listening on port **5000**, also start the **Subscriber** project.

- Run a `POST /notifications` call for API service, with the next body:

  ```json
  {
    "channel": "hello",
    "message": "Hey there!"
  }
  ```
- After last request, the Subscriber should have received the message.