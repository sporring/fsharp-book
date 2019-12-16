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
  member this.stopWatch() = _sw

printfn "Creating a scope"
let mutable refToEx : Stopwatch option = None
(
  use ex = new example()
  ex.showDuration()
  refToEx <- Some (ex.stopWatch());
)
printfn "Scope deleted"
Thread.Sleep(10000)
try
  Option.iter (fun (elm : Stopwatch) -> printfn "%A" elm.Elapsed) refToEx
with
  _ -> printfn "Reference was deleted"
printfn "Program done"
