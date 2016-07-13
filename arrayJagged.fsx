let A = [| for n in 1..3 do yield [| 1 .. n |] |]
  
let printArrayOfArrays (a : int array array) =           
  for i = 0 to a.Length - 1 do
    for j = 0 to a.[i].Length - 1 do
      printf "%d " a.[i].[j]
    printf "\n"
     
printArrayOfArrays A
