open System.Windows.Forms
open System.Drawing
open System

let win = new Form () // create a form

// Window event
let windowMove (e : EventArgs) =
  printfn "Move: %A" win.Location
win.Move.Add windowMove

let windowResize (e : EventArgs) =
  printfn "Resize: %A" win.DisplayRectangle
win.Resize.Add windowResize

// Mouse event
let mutable record = false; // records when button down
let mouseMove (e : MouseEventArgs) =
  if record then printfn "MouseMove: %A" e.Location
win.MouseMove.Add mouseMove

let mouseDown (e : MouseEventArgs) =
  printfn "MouseDown: %A" e.Location; (record <- true)
win.MouseDown.Add mouseDown

let mouseUp (e : MouseEventArgs) =
  printfn "MouseUp: %A" e.Location; (record <- false)
win.MouseUp.Add mouseUp

let mouseClick (e : MouseEventArgs) =
  printfn "MouseClick: %A" e.Location
win.MouseClick.Add mouseClick

// Keyboard event
win.KeyPreview <- true
let keyPress (e : KeyPressEventArgs) =
  printfn "KeyPress: %A" (e.KeyChar.ToString ())
win.KeyPress.Add keyPress

Application.Run win // Start the event-loop.
