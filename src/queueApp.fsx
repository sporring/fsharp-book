open Queue

let q = create () |> enqueue 3 |> enqueue 1
printfn "q = %A" q
printfn "Is q empty? %A" (isEmpty q)
let (v,newQ) = dequeue q
printfn "dequeue q = (%A, %A)" v newQ
