/// Create a form and add a paint function
let createForm backgroundColor (width, height) title draw =
  let win = new System.Windows.Forms.Form ()
  win.Text <- title
  win.BackColor <- backgroundColor
  win.Size <- System.Drawing.Size (width, height)
  win.Paint.Add draw
  win
  
/// Draw a polygon with a specific color
let drawPoints (coords : (float * float) list) (color : System.Drawing.Color) (e : System.Windows.Forms.PaintEventArgs) =
  let pairToPoint (x : float, y : float) =
    System.Drawing.Point (int (round x), int (round y))
  let pen = new System.Drawing.Pen (color)
  let Points = Array.map pairToPoint (List.toArray coords)
  e.Graphics.DrawLines (pen, Points)
  
// Setup drawing details
let title = "My second window"
let backgroundColor = System.Drawing.Color.White
let size = (400, 200)
let coords = [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let color = System.Drawing.Color.Black

// Create form and start the event-loop.
let win = createForm backgroundColor size title (drawPoints coords color) 
System.Windows.Forms.Application.Run win // win.Show()
