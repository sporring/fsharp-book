let printFile (reader : System.IO.StreamReader) =
  while not(reader.EndOfStream) do
    let line = reader.ReadLine ()
    printfn "%s" line
          
let filename = "readFile.fsx"
let reader = System.IO.File.OpenText filename
printFile reader
