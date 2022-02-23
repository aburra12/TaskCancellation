This example shows how to terminate a Task and its children in response to a cancellation request.

It also shows that when a user delegate terminates by throwing a TaskCanceledException, the calling thread can optionally use the Wait method or WaitAll method to wait for the tasks to finish.

4 strategies are available in order to cancel a long running work

ManualCancellation : cancel long running cancellable work when pressing a cancel key

TimeoutCancellation : cancel long running cancellable work after a timeout delay

WrappedCancellation : wrap long running non cancellable work using a cancellation token

CompositeCancellation : cancel long running cancellable work using multiple cancellation tokens

In this case, you must use a try/catch block to handle the exceptions on the calling thread.