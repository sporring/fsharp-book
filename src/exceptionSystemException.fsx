let _ =
  try
    failwith "Arrrrg"
  with
    :? System.Exception -> printfn "So failed"
