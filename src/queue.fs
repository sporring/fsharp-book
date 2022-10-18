module Queue

type element = int
type queue = element list

// the empty queue
let create () : queue = [] 
// add an element at the end of a queue
let enqueue (e: element) (q: queue) : queue =
  q @ [e]
// check if the queue is empty
let isEmpty (q:queue): bool =
  q.IsEmpty
// remove the element at the front of the queue
let dequeue (q: queue) : (element option) * queue =
  match q with
    [] -> (None, [])
    | e::rst -> (Some e, rst)
