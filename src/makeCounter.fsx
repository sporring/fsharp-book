let makeCounter () =
  let mutable s = 0
  fun () ->
    s <- s + 1
    s

let inc = makeCounter ()
printfn "%A" (inc ())
printfn "%A" (inc ())
printfn "%A" (inc ())
