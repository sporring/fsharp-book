let (|Div|_|) (e,d) = if d <> 0.0 then Some (e/d) else None

let safeDiv (p : float * float) =
    match p with
      | (0.0, 0.0) -> printfn "Div %A = undefined" p
      | Div res -> printfn "Div %A = %A" p res (*//§\label{activeOptionPatternApp}§*)
      | _ -> printfn "Div %A = infinity" p

List.iter safeDiv [(1.0,1.0); (0.0,1.0); (1.0,0.0); (0.0,0.0)]
