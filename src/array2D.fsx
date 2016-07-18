let A = Array2D.create 3 4 0
for i = 0 to (Array2D.length1 A) - 1 do
  for j = 0 to (Array2D.length2 A) - 1 do
    A.[i,j] <- pown (j + 1) (i + 1)

let printArray2D (a : int [,]) =
  for i = 0 to (Array2D.length1 a) - 1 do
    for j = 0 to (Array2D.length2 a) - 1 do
      printf "%2d " a.[i, j]
    printf "\n"

printArray2D A
