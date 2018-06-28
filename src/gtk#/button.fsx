// Explicit references has the advantage that
//   intellisense with libraries,
//   fsharpc does not require linking when compiling,
//   but is installation specific
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/gtk-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/glib-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/atk-sharp.dll"

open Gtk

//Initialize application
Application.Init()
//Create a window
let win = new Window("My first GTK# Application! ");
win.DeleteEvent.Add(fun e -> win.Hide(); Application.Quit(); e.RetVal <- true)

//Create buttons and a label
let box = new VBox()
win.Add(box);

let btnUp = new Button("Increment", Visible=true)
box.Add btnUp

let btnDown = new Button("Decrement", Visible=true)
box.Add btnDown

let lbl = new Label(Text=" Count: 0", Visible=true)
box.Add lbl

Event.merge (btnUp.Clicked |> Event.map (fun _ -> +1)) (btnDown.Clicked |> Event.map (fun _ -> -1))
  |> Event.scan (+) 0
  |> Event.map (sprintf " Count: %d")
  |> Event.add (fun s -> lbl.Text <- s)
  
//Show all
win.ShowAll()

//Run application
Application.Run()
