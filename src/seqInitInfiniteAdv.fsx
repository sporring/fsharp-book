let repeat (lst : 'a list) : 'a seq =
  Seq.initInfinite (fun i -> lst[i % (lst.Length)])
let infSeq = repeat [1;2;3]
printfn "%A" infSeq
for i in 0..10 do
  printf "%d " (Seq.item i infSeq)
printfn ""
