let arr = Array2D.create 3 4 0
for i = 0 to (Array2D.length1 arr) - 1 do
  for j = 0 to (Array2D.length2 arr) - 1 do
    arr[i,j] <- j * Array2D.length1 arr + i
printfn "%A" arr
