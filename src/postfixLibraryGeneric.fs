module stack

type stack<'a> = 'a list
let init () : stack<'a> = [] 
let pop (stck: stack<'a>) : 'a*stack<'a> =  (stck.Head, stck.Tail)
let push (elm: 'a) (stck: stack<'a>): stack<'a> = elm::stck
let isEmpty (stck: stack<'a>): bool = stck.IsEmpty