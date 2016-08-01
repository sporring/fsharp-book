let sq = seq { 1 .. 3 }
let lst = Seq.toList sq (* convert sequence to list *)
let arr = Seq.toArray sq (* convert sequence to array *)
let sqFromArr = seq [| 1 .. 3|] (* convert an array to sequence *)
let sqFromLst = seq [1 .. 3] (* convert a list to sequence *)
printfn "%A, %A, %A, %A, %A" sq lst arr sqFromArr sqFromLst 
