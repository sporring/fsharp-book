// file: glade.cs
open Gtk;
open Glade;

type GladeApp (args : string[]) as this =
  do Application.Init()
  let gxml = new Glade.XML ("gui.glade", "window1", null)
  do gxml.Autoconnect (this)
  do Application.Run()

  [<Widget>]
  [<DefaultValue(true)>]
  val mutable button1 : Button 

  [<Widget>]
  [<DefaultValue(true)>]
  val mutable label1 : Label

  let OnPressButtonEvent () =
     printfn "Button press"
     this.label1.Text <- "Mono"

  do this.button1.Clicked |> Event.add (fun _ -> OnPressButtonEvent ()) 

[<EntryPoint>]
let main(args : string[]) =
  new GladeApp (args)
  0
