open System.Diagnostics
open System.Threading

type example () =
  let _sw = Stopwatch.StartNew()
  do printfn "Instantiated example-object"
  override this.Finalize() =
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
  let ex = example()
  ex.showDuration()
)
printfn "Scope deleted"
Thread.Sleep(10000)
printfn "Program done"
