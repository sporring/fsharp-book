let rec map f lst =
  match lst with
    [] -> []
    | e::rst -> (f e)::map f rst

let newList = map (fun x->x+1) [2; 3; 5]
printfn "%A" newList
