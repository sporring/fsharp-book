module stack

type stack = int list // a stack of elements

// create an empty stack
val init: unit -> stack
// return the top element and the resulting stack
val pop: stack -> int * stack
// put an element on a stack and return the resulting stack
val push: int -> stack -> stack
// check whether the stack is empty
val isEmpty: stack -> bool
