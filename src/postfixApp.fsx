open Stack

type element = Value of float | Mul | Add | Sub | Div

let tokens = [Value 4.0; Value 6.0; Value 3.0; Mul; Add; Value 2.0; Div; Value 8.0; Sub]

let rec eval (tkns: element list) (stck: stack): stack =
  match tkns with
    [] -> stck
    | elm::rst ->
      match elm with
        Value v -> 
          push v stck |> eval rst
        | Mul -> 
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b*a) stck2 |> eval rst
        | Add ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b+a) stck2 |> eval rst
        | Sub ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b-a) stck2 |> eval rst
        | Div ->
          let (a, stck1) = pop stck
          let (b, stck2) = pop stck1
          push (b/a) stck2 |> eval rst

printfn "%A = %A" tokens (eval tokens (create ()))
