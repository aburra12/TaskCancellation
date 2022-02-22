This example shows how to terminate a Task and its children in response to a cancellation request.

It also shows that when a user delegate terminates by throwing a TaskCanceledException, the calling thread can optionally use the Wait method or WaitAll method to wait for the tasks to finish.

In this case, you must use a try/catch block to handle the exceptions on the calling thread.