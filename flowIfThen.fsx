let printOnlyPostiveValues x =
  if x > 0 then
    printfn "%d" x
printOnlyPostiveValues 3
printOnlyPostiveValues -3
