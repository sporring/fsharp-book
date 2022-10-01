open stack

type element = Value of int | Multiply | Plus | Minus | Divide

let tokens = [Value 4; Value 6; Value 3; Multiply; Plus; Value 2; Divide; Value 8; Minus]

let rec eval (tkns: element list) (stck: stack<int>): stack<int> =
  match tkns with
    [] -> stck
    | elm::rst ->
      match elm with
        Value v -> 
          push v stck |> eval rst
        | Multiply -> 
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b*a) stck2 |> eval rst
        | Plus ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b+a) stck2 |> eval rst
        | Minus ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b-a) stck2 |> eval rst
        | Divide ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b/a) stck2 |> eval rst

printfn "%A = %A" tokens (eval tokens (init ()))
