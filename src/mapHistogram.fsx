let rec hist (lst: char list) (m: Map<char,int>) : Map<char,int> = 
  match lst with
    [] -> m
    | c::rst ->
      match (Map.tryFind c m) with
        None -> hist rst (Map.add c 1 m)
        | Some v -> hist rst (Map.add c (v+1) m)

let txt = "many years ago, there was an emperor, who was so excessively fond of new clothes, that he spent all his money in dress."
let lst = Seq.toList txt // Converts to a list of characters
let h = hist lst Map.empty

printfn "The text %A has the histogram\n%A" txt h
