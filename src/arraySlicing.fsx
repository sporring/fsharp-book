let arr = [|'a' .. 'g'|]
printfn "%A" arr[0]
printfn "%A" arr[3]
printfn "%A" arr[3..]
printfn "%A" arr[..3]
printfn "%A" arr[1..3]
printfn "%A" arr[*]
