open System
open System.Windows.Forms
open FSharp.Charting
 
[<EntryPoint>]
[<STAThread>]
let main argv = 
  Application.EnableVisualStyles()
  Application.SetCompatibleTextRenderingDefault false
 
  Application.Run (Chart.Line([ for x in 0 .. 10 -> x, x*x ]).ShowChart())

  0
