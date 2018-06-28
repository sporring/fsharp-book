let div enum denom =
  if denom = 0 then
    raise (System.ArgumentException "Error: \"division by 0\"")
  else
    enum / denom

printfn "3 / 0 = %s" (try (div 3 0 |> string) with ex -> ex.Message)
