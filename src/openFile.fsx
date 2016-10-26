let filename = "openFile.fsx"

let reader =
  try
    Some (System.IO.File.Open (filename, System.IO.FileMode.Open))
  with
    _ -> None

if reader.IsSome then
  printfn "The file %A was successfully opened." filename
  reader.Value.Close ()
