let pownArray  (arr : int array array) p =
  for i = 1 to arr.Length - 1 do
    for j = 1 to arr[i].Length - 1 do
      arr[i][j] <- pown arr[i][j] p

let printArrayOfArrays (arr : int array array) =           
  for row in arr do
    for elm in row do
      printf "%3d " elm
    printf "\n"
   
let A = [|[|1 .. 4|]; [|1 .. 2 .. 7|]; [|1 .. 3 .. 10|]|]
pownArray A 2
printArrayOfArrays A
