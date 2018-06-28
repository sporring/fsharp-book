let repeat items =
  let rec ret =
    seq { yield! items  
          yield! ret }
  ret

printfn "%A" (repeat [1;2;3])
  
