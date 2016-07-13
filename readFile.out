let rec printFile (reader : System.IO.StreamReader) =
  if not(reader.EndOfStream) then
    let line = reader.ReadLine ()
    printfn "%s" line
    printFile reader
          
let filename = "readFile.fsx"
let reader = System.IO.File.OpenText filename
printFile reader
