let rec getAFileName () =
  System.Console.Write("Enter Filename: ")
  let filename = System.Console.ReadLine()
  if System.IO.File.Exists filename then filename
  else getAFileName ()

let listOfFiles = System.IO.Directory.GetFiles "."
printfn "Directory contains: %A" listOfFiles
let filename = getAFileName ()
printfn "You typed: %s" filename
