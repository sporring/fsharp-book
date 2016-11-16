open System.Windows.Forms
open System.Drawing

type coordinates = (float * float) list
type pen = Color * float

/// Create a form and add a paint function
let createForm backgroundColor (width, height) title draw =
  let win = new Form ()
  win.Text <- title
  win.BackColor <- backgroundColor
  win.ClientSize <- Size (width, height)
  win.Paint.Add draw
  win

/// Draw a polygon with a specific color
let drawPoints (coords : coordinates) (pen : pen) (e : PaintEventArgs) =
  let pairToPoint (x : float, y : float) =
    Point (int (round x), int (round y))
  let color, width = pen
  let Pen = new Pen (color, single width)
  let Points = Array.map pairToPoint (List.toArray coords)
  e.Graphics.DrawLines (Pen, Points)
  
// Setup drawing details
let title = "A well organized triangle"
let backgroundColor = Color.White
let size = (400, 200)
let coords = [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let pen = (Color.Black, 1.0)

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints coords pen) 
Application.Run win
