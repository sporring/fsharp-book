module stack

type stack = int list
let init () : stack = [] 
let pop (stck: stack) : int*stack =  (stck.Head, stck.Tail)
let push (elm: int) (stck: stack): stack = elm::stck
let isEmpty (stck: stack): bool = stck.IsEmpty