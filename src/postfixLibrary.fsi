module Stack

type stack = float list // a stack of elements

// create an empty stack
val create: unit -> stack
// return the top element and the resulting stack
val pop: stack -> float * stack
// put an element on a stack and return the resulting stack
val push: float -> stack -> stack
// check whether the stack is empty
val isEmpty: stack -> bool
