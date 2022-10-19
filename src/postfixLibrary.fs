module Stack

type stack = float list
let create () : stack = [] 
let pop (stck: stack) : float*stack =  (stck.Head, stck.Tail)
let push (elm: float) (stck: stack): stack = elm::stck
let isEmpty (stck: stack): bool = stck.IsEmpty