open System.Windows.Forms
open System.Drawing

type coordinates = (float * float) list
type pen = Color * float
type polygon = coordinates * pen

/// Create a form and add a paint function
let createForm backgroundColor (width, height) title draw =
  let win = new Form ()
  win.Text <- title
  win.BackColor <- backgroundColor
  win.Size <- Size (width, height)
  // Paint event
  win.Paint.Add draw
  // Window event
  win.Move.Add (fun e -> printfn "Move: %A" win.Location)
  win.Resize.Add (fun _ -> printfn "Resize: %A" win.DisplayRectangle)
  // Mouse event
  let mutable record = false;
  win.MouseMove.Add (fun e -> if record then printfn "MouseMove: %A" e.Location)
  win.MouseDown.Add (fun e -> printfn "MouseDown: %A" e.Location; (record <- true))
  win.MouseUp.Add (fun e -> printfn "MouseUp: %A" e.Location; (record <- false))
  win.MouseClick.Add (fun e -> printfn "MouseClick: %A" e.Location)
  // Keyboard event
  win.KeyPreview <- true
  win.KeyPress.Add (fun e -> printfn "KeyPress: %A" (e.KeyChar.ToString ()))
  win

/// Draw a polygon with a specific color
let drawPoints (polygLst : polygon list) (e : PaintEventArgs) =
  let pairToPoint (x : float, y : float) =
    Point (int (round x), int (round y))

  for polyg in polygLst do
    let coords, (color, width) = polyg
    let pen = new Pen (color, single width)
    let Points = Array.map pairToPoint (List.toArray coords)
    e.Graphics.DrawLines (pen, Points)
    
let backgroundColor = System.Drawing.Color.White
let title = "Window events"
let size = (200, 200)
let polygLst = []

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
System.Windows.Forms.Application.Run win
