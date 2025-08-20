let repeat items =
  seq { while true do yield! items }

printfn "%A" (repeat [1;2;3])
  
