let inc x = x + 1
let newList = List.map inc [2; 3; 5]
printfn "%A" newList
