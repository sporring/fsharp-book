let rec repeat items =
  seq { yield! items  
        yield! repeat items }

printfn "%A" (repeat [1;2;3])
  
