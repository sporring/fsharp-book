open System.IO

let writeToFile (filename : string) (str : string) : unit =
   use file = File.CreateText filename
   file.Write str
   // file.Dispose() is implicitely called here,
   // implying that the file is closed.

writeToFile "use.txt" "Using 'use' closes the file, when out of scope."
