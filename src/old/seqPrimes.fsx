let s = Seq.initInfinite (fun i -> i+2)
let isPrime n =
  let maxTestValue =  n |> float |> sqrt |> int
  List.forall (fun x -> n % x <> 0) [ 2 .. maxTestValue ]  

let primes = Seq.filter isPrime s
for i in 0..1000 do
  printf "%d " (Seq.item i primes)
printfn "";
