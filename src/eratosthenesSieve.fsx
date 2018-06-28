let s = Seq.initInfinite (fun i -> i+2)

let rec sieve (acc : int seq) (haystack : int seq) (v : int) : int seq = 
  let test = Seq.item 0 haystack
  if test <= v then
    sieve (Seq.append acc (Seq.singleton test)) (Seq.filter (fun e -> e % test <> 0) haystack) v
  else
    acc

let maxPrime = 7927
let primes = sieve Seq.empty<int> s maxPrime
printfn "%A" primes
for i in primes do
  printf "%d " i
printfn "";
