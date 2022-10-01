module stack

type stack<'a> = 'a list // a stack of elements

// create an empty stack
val init: unit -> stack<'a>
// return the top element and the resulting stack
val pop: stack<'a> -> 'a * stack<'a>
// put an element on a stack and return the resulting stack
val push: 'a -> stack<'a> -> stack<'a>
// check whether the stack is empty
val isEmpty: stack<'a> -> bool
