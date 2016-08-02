let repeat items =
  let get items x = Seq.item (x % (Seq. length items)) items
  Seq.initInfinite (get items)

printfn "%A"  (repeat [1;2;3])
