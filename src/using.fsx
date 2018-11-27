open System.IO

let writeToFile (str : string) (file : StreamWriter) : unit =
   file.Write str

using (File.CreateText "use.txt") (writeToFile "Disposed after call.")
// Dispose() is implicitly called on the anonymous file handle, implying
// that the file is automatically closed.
