///////////// Model /////////////
type Point = float * float // any finite values
type Color = float * float * float // values 0.0 to 1.0
type Primitive =
  | Lines of Point list
  | Circle of Point*float // point and a positive radius
  | Pen of Color*float // color and a positive width

/// Translate a primitive
let translate (d : Point) (p : Primitive) : Primitive =
  let add (dx, dy) (x, y) = (dx + x, dy + y)
  match p with
    | Lines lst -> Lines (List.map (add d) lst)
    | Circle (P1,r) -> Circle (add d P1,r)
    | _ -> p

/// Rotate a primitive
let rotate (theta : float) (p : Primitive) : Primitive =
  let rot t (x,y) = (x * cos t - y * sin t, x * sin t + y * cos t)
  match p with
    | Lines lst -> Lines (List.map (fun P -> rot theta P) lst)
    | Circle (P,r) -> Circle (rot theta P,r)
    | _ -> p

/// Scale a primitive
let scale (s : float) (p : Primitive) : Primitive =
  let mul s (x,y) = (s * x, s * y)
  match p with
    | Lines lst -> Lines (List.map (fun P -> mul s P) lst)
    | Circle (P,r) -> Circle (mul s P, s * r)
    | _ -> p

// Setup drawing details
let S = 300.0
let size = (S, S)
let clock (h : float) (m : float) (s : float) : Primitive list =
  let origin = (0.5, 0.5)
  let secHand =
    Lines [(0.0, 0.0); (0.0, -0.4)]
    |> translate origin
  let minHand =
    Lines [(0.016, 0.0); (-0.016, 0.0); (0.0, -0.4); (0.016, 0.0)]
    |> translate origin
  let hourHand =
    Lines [(0.016, 0.0); (-0.016, 0.0); (0.0, -0.25); (0.016, 0.0)]
    |> translate origin
  let shape = 
    [ Pen ((0.0, 0.0, 0.0), S / 200.0);
      Circle (origin, 0.46);
      secHand
      |> translate (- fst origin, - snd origin)
      |> rotate (s * 2.0 * System.Math.PI / 60.0)
      |> translate origin;
      minHand
      |> translate (- fst origin, - snd origin)
      |> rotate (m * 2.0 * System.Math.PI / 60.0)
      |> translate origin;
      hourHand
      |> translate (- fst origin, - snd origin)
      |> rotate (h * 2.0 * System.Math.PI / 12.0)
      |> translate origin; ]
  List.map (scale S) shape

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
    | Circle ((x,y), r) ->
      let n = max 3.0 (ceil (2.0 * System.Math.PI * r))
      let arr = [|0.0 .. 1.0 / n .. 2.0*System.Math.PI|] // angular samples
      DrawingLines (Array.map (fun v -> pointToDrawingPoint (x + r * cos v, y + r * sin v)) arr)
    | Pen ((r,g,b), w) ->
      let (R,G,B) = (toInt (255.0*r), toInt (255.0*g), toInt (255.0*b))
      DrawingPen (new System.Drawing.Pen (System.Drawing.Color.FromArgb (R,G,B), single w))

let clockDrawing h m s =
  List.map primitivesToDrawing (clock h m s)

///////////// WinForm specifics /////////////
// Open Window using WinForm and display clock
let win = new System.Windows.Forms.Form ()
win.Text <- "Transforming polygons"
win.BackColor <- System.Drawing.Color.White
win.ClientSize <- System.Drawing.Size ((int << fst) size, (int << snd) size)
let mutable pen = new System.Drawing.Pen (System.Drawing.Color.Black, 1.0f)
let paint (e : System.Windows.Forms.PaintEventArgs) (d : Drawing) : unit = 
  match d with
  | DrawingLines arr -> e.Graphics.DrawLines (pen, arr)
  | DrawingPen p ->
    pen.Dispose();
    pen <- p
win.Paint.Add (fun e ->
               let h = float System.DateTime.Now.Hour
               let m = float System.DateTime.Now.Minute
               let s = float System.DateTime.Now.Second
               List.iter (paint e) (clockDrawing h m s))

let timer = new System.Windows.Forms.Timer()
timer.Interval <- 1000
timer.Enabled <- true
timer.Tick.Add (fun e -> win.Refresh ())

System.Windows.Forms.Application.Run win
