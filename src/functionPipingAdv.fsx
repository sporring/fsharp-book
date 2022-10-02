let lst = [1.0..3.0]
// regular composition
printfn "%A" (List.map (fun x -> log (sqrt x)) lst)
// piping operator
printfn "%A" (List.map (fun x -> x |> sqrt |> log) lst)
printfn "%A" (List.map (fun x -> log <| (sqrt <| x)) lst)
// composition operator
printfn "%A" (List.map (sqrt>>log) lst)
printfn "%A" (List.map (log<<sqrt) lst)
