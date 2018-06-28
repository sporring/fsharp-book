// file: glade.cs
open Gtk;
open Glade;

let mutable click_count = 0

type Handler () =
   [<Widget>]
   [<DefaultValue>]
   val mutable button1 : Button // A member whose value is defined externally
       
   [<Widget>]
   [<DefaultValue>]
   val mutable label1 : Label
       
   [<Widget>]
   [<DefaultValue>]
   val mutable window1 : Window

let OnClick (h : Handler) =
  click_count <- click_count + 1
  h.label1.Text <- sprintf "Click %d" click_count

let OnDelete (args:DeleteEventArgs) =
  Application.Quit()
  args.RetVal <- true  

[<EntryPoint>]
let main (args : string[]) =
  Application.Init()
  let gxml = new Glade.XML ("gui.glade", "window1", null)

  let handler = new Handler()
  gxml.Autoconnect (handler)
  handler.button1.Clicked |> Event.add (fun _ -> OnClick handler)
  handler.window1.DeleteEvent |> Event.add OnDelete

  handler.window1.ShowAll()
  Application.Run()
  0
