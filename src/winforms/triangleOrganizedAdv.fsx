///////////// Model /////////////
type Point = float * float // any finite values
type Color = float * float * float // values 0.0 to 1.0
type Primitive =
  | Lines of Point list
  | Pen of Color*float // color and a positive width
  
// Setup drawing details
let size = (350.0, 200.0)
let coords = Lines [(0.0, 0.0); (10.0, 170.0); (320.0, 20.0); (0.0, 0.0)]
let penColor = Pen ((0.0, 0.0, 0.0), 1.0)
let shape = [penColor; coords]

///////////// Connect layer between model and WinForm /////////////
type Drawing =
  | DrawingLines of System.Drawing.Point []
  | DrawingPen of System.Drawing.Pen

let toInt = int << round
let pointToDrawingPoint (p : Point) : System.Drawing.Point =
  System.Drawing.Point ((toInt << fst) p, (toInt << snd) p)
let primitivesToDrawing (p : Primitive) : Drawing =
  match p with
    | Lines lst ->
      DrawingLines (List.map pointToDrawingPoint lst |>  List.toArray)
    | Pen ((r,g,b), w) ->
      let (R,G,B) = (toInt (255.0*r), toInt (255.0*g), toInt (255.0*b))
      DrawingPen (new System.Drawing.Pen (System.Drawing.Color.FromArgb (R,G,B), single w))

let pts = List.map primitivesToDrawing shape
  
///////////// WinForm specifics /////////////
// Open Window using WinForm and display turtle curve
let win = new System.Windows.Forms.Form ()
win.Text <- "An organized triangle"
win.BackColor <- System.Drawing.Color.White
win.ClientSize <- System.Drawing.Size ((int << fst) size, (int << snd) size)
let mutable pen = new System.Drawing.Pen (System.Drawing.Color.Black, 1.0f)
let paint (e : System.Windows.Forms.PaintEventArgs) (d : Drawing) : unit = 
  match d with
  | DrawingLines arr -> e.Graphics.DrawLines (pen, arr)
  | DrawingPen p ->
    pen.Dispose();
    pen <- p
win.Paint.Add (fun e -> List.iter (paint e) pts)
System.Windows.Forms.Application.Run win
