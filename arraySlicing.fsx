let A = [| 1; 2; 3; 4; 5 |]
let B = A.[1..3]
let C = A.[..2]
let D = A.[3..]
let E = A.[*]
  
let printArray (a : int array) =
  for i = 0 to a.Length - 1 do
    printf "%d " a.[i]
  printf "\n"

printArray A
printArray B
printArray C
printArray D
printArray E
