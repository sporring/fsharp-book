let filename = "openFile.fsx"
// Open the file and return the stream value as an option type
let reader =
  try
    Some (System.IO.File.Open (filename, System.IO.FileMode.Open))
  with
    _ -> None

// Do something with the file
if reader.IsSome then
  printfn "The file %A was successfully opened." filename

// If the file was opened, then it must be closed
if reader.IsSome then    
  reader.Value.Close ()
