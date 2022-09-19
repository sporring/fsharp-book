type Lst = Ground | Element of int*Lst

let lst = Element (1, Element (2, Element (3, Ground)))
printfn "%A" lst
