module Array2D =
  let toArray (arr: 'T [,]) = arr |> Seq.cast<'T> |> Seq.toArray
