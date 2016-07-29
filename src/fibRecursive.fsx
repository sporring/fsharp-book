let rec fib n =
  match n with
    i when i < 1 -> 0
    | i when i = 1 -> 1
    | i -> fib (n - 1) + fib (n - 2)

for i = 0 to 10 do
  printfn "fib(%d) = %d" i (fib i)
