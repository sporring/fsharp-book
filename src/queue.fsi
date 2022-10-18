// the empty queue
val create: unit -> queue
// add an element at the end of a queue
val enqueue: element -> queue -> queue
// check if the queue is empty
val isEmpty: queue -> bool
// remove the element at the front of the queue
val dequeue: queue -> element option * queue
