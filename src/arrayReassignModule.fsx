let A = [| 1 .. 5 |]

let printArray (a : int array) =
  Array.iter (fun x -> printf "%d " x) a
  printf "\n"

let square a = a * a
    
printArray A
let B = Array.map square A
printArray A
printArray B
