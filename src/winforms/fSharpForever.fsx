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
  win.ClientSize <- Size (width, height)
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
    
/// Translate a point
let translatePoint (dx, dy) (x, y) =
  (x + dx, y + dy)

/// Translate point array
let translatePoints (dx, dy) arr =
  List.map (translatePoint (dx, dy)) arr

/// Rotate a point
let rotatePoint theta (x, y) =
  (x * cos theta - y * sin theta, x * sin theta + y * cos theta)

/// Rotate point array
let rotatePoints theta arr =
  List.map (rotatePoint theta) arr

type curve = float * float * coordinates

/// Turn 90 degrees left
let left (l, dir, c) : curve = (l, dir + 3.141592/2.0, c)

/// Turn 90 degrees right
let right (l, dir, c) : curve = (l, dir - 3.141592/2.0, c)

/// Add a line to the curve of present direction
let forward (l, dir, c) : curve =
  let nextPoint = rotatePoint dir (l, 0.0)
  (l, dir, c @ [translatePoint c.[c.Length-1] nextPoint])

let scale factor (l, dir, c) = (factor*l, dir, c @ [c.[c.Length-1]])

/// Find the maximum value of each coordinate element in a list
let maximum (c : coordinates) =
  let maxPoint p1 p2 =
    (max (fst p1) (fst p2), max (snd p1) (snd p2))
  List.fold maxPoint (-infinity, -infinity) c

// Calculate curve
let order = 10
let l = 500.0
let t = 0.1
let startingFactor = 1.0 - 2.0*t
let mutable polygLst = []
for i = 1 to order do
  let factor = pown startingFactor (i-1)
  let width = l * factor
  let topLeft = (l * (1.0 - factor) / 2.0 , l * (1.0 - factor) / 3.0)
  printfn "width, topLeft: %A %A" width topLeft
//  let (_, dir, c) = (l * (pown 0.8 (i-1)), 0.0, [(0.0 + (float (i - 1)) * t * l, 0.0 + 0.5 * (float (i - 1)) * t * l)]) |> forward |> left |> forward |> left |> forward |> left |>  forward
  let (_, dir, c) = (width, 0.0, [topLeft]) |> forward |> left |> forward |> left |> forward |> left |>  forward
  printfn "c: %A" c
  polygLst <- (c, (Color.Black, 2.0))::polygLst
printfn "polygLst: %A" polygLst

// Setup drawing details
let title = "A square"
let backgroundColor = Color.White
let cMax = maximum (List.collect fst polygLst)
let size = (int (fst cMax)+1, int (snd cMax)+1)

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints polygLst) 
Application.Run win