let printArray (arr : int array) =
  for elm in arr do
    printf "%d " elm
  printf "\n"

let printArrayAlt (arr : int array) =
  for i = 0 to arr.Length - 1 do
    printf "%A " arr[i]
  printfn ""

let a = [|1; 2;|]
let b = [|3; 4; 5|]
let c = Array.append a b
printfn "%A, %A, %A" a b c
printArray c
printArrayAlt c
