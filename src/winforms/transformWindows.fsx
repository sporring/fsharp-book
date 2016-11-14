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
  win.Paint.Add draw
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
    
/// Translate point array
let translatePoints (dx, dy) arr =
  let translatePoint (dx, dy) (x, y) =
    (x + dx, y + dy)
  List.map (translatePoint (dx, dy)) arr

/// Rotate point array
let rotatePoints theta arr =
  let rotatePoint theta (x, y) =
    (x * cos theta - y * sin theta, x * sin theta + y * cos theta)
  List.map (rotatePoint theta) arr

// Setup drawing details
let title = "Transforming polygons"
let backgroundColor = Color.White
let size = (400, 200)
let points = [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let polygLst =
  [(points, (Color.Black, 1.0));
   (translatePoints (40.0, 30.0) points, (Color.Red, 2.0));
   (rotatePoints (1.0 *System.Math.PI / 180.0) points, (Color.Green, 1.0))]

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
System.Windows.Forms.Application.Run win
