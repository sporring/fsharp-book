open bTree

let rec sortInsert (acc: bTree<int>) (elm: int): bTree<int> =
  let v = retrieveValue acc
  let l = tryRetrieveLeft acc
  let r = tryRetrieveRight acc
  if elm < v then
    match l with
      None -> replaceLeft (create elm) acc
      | Some t -> replaceLeft (sortInsert t elm) acc
  else
    match r with
      None -> replaceRight (create elm) acc
      | Some t -> replaceRight (sortInsert t elm) acc

let rnd = System.Random()
let unsrt = List.map (fun _ -> rnd.Next 10) [1..10]
let srt = List.fold sortInsert (create unsrt.Head) unsrt.Tail
printfn "Unsorted list:\n%A\nSorted:\n%A" unsrt (infix srt)
