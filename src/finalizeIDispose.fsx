open System.Diagnostics
open System.Threading

type example () =
  let _sw = Stopwatch.StartNew()
  do printfn "Instantiated example-object"
  interface System.IDisposable with 
    member this.Dispose() = 
      printfn "Finalizing example-object"
      try
        _sw.Stop();
        this.showDuration()
      with
        _ -> printfn "Stopwatch problems"
  member this.showDuration() =
    printfn "This instance has been in existence for %A" _sw.Elapsed

printfn "Creating a scope"
(
  use ex = new example()
  ex.showDuration()
)
printfn "Scope deleted"
Thread.Sleep(10000)
printfn "Program done"
