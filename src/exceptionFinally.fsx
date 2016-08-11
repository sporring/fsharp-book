let _ =
  try
    if true then failwith "True"
    else failwith "False"
  finally
    printfn "Finally expression will always be executed."
