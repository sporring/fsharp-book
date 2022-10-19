open Stack

create () |> push 1.0 |> push 2.0 |> pop |> printfn "%A"
create () |> push 'a' |> push 'b' |> pop |> printfn "%A"
