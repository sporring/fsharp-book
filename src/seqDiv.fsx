let rec seqDiv acc lst = 
  match lst with
    | [] -> acc
    | elm::rest when elm <> 0.0 -> seqDiv (acc/elm) rest
    | _ -> failwith "Division by zero"

try
  printfn "%A" (seqDiv 1.0 [1.0; 2.0; 3.0])
  printfn "%A" (seqDiv 1.0 [1.0; 0.0; 3.0])
with
  Failure msg -> printfn "%s" msg
