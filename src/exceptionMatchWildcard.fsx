let _ =
  try
    failwith "Arrrrg"
  with
    _ -> printfn "So failed"
