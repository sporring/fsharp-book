let pownArray  (a : int array) p =
  for i = 0 to a.Length - 1 do
    a.[i] <- pown a.[i] p
  a

let A = [| for n in 1..3 do yield (pownArray [| 1 .. 4 |] n ) |]

let printArrayOfArrays (a : int array array) =           
  for i = 0 to a.Length - 1 do
    for j = 0 to a.[i].Length - 1 do
      printf "%2d " a.[i].[j]
    printf "\n"
   
printArrayOfArrays A
