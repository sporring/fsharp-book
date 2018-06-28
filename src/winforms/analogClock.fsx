// Open often used libraries, be ware of namespace polution!
open System.Windows.Forms
open System.Drawing
open System

///////////// WinForm specifics /////////////
/// Setup a window form and return function to activate
let view (sz : SizeF) (clock : DateTime -> (Pen * (PointF [])) list) (txt : DateTime -> string) : (unit -> unit) =
  let win = new System.Windows.Forms.Form ()
  win.ClientSize <- Size (int sz.Width, int sz.Height)

  let label = new Label ()
  win.Controls.Add label
  label.Width <- win.ClientSize.Width
  label.Location <- Point (0, int (0.94 * (float sz.Height)))
  label.AutoSize <- false
  label.TextAlign <- ContentAlignment.MiddleCenter
  label.Dock <- DockStyle.None
  
  let paint (e : PaintEventArgs) ((p, lines) : (Pen * (PointF []))) : unit = 
    e.Graphics.DrawLines (p, lines)
  win.Paint.Add (fun e ->
                 let now = DateTime.Now
                 label.Text <- txt now
                 List.iter (paint e) (clock now))

  let timer = new System.Windows.Forms.Timer()
  timer.Interval <- 1000
  timer.Enabled <- true
  timer.Tick.Add (fun e -> win.Refresh ())

  fun () -> Application.Run win // function as return value

///////////// Model /////////////
let model () : SizeF * (DateTime -> (Pen * (PointF [])) list) * (DateTime -> string) = 
  /// Translate a primitive
  let translate (d : PointF) (arr : PointF []) : PointF [] =
    Array.map (fun (p : PointF) -> PointF (d.X + p.X, d.Y + p.Y)) arr

  /// Rotate a primitive
  let rotate (theta : single) (arr : PointF []) : PointF [] =
    let rot (t : single) (p : PointF) : PointF =
      let (cost, sint) = (single (cos t), single(sin t))
      let (a, b) = (p.X * cost - p.Y * sint, p.X * sint + p.Y * cost)
      PointF (single a, single b)
    Array.map (rot theta) arr

  /// Scale a primitive
  let scale (s : single) (arr : PointF []) : PointF [] =
    Array.map (fun (p : PointF) -> PointF (s * p.X, s * p.Y)) arr
      
  let S = 300.0f
  let size = SizeF (S, S)
  let origin = PointF (0.5f, 0.5f)
  let r = 0.43f
  let pi = single System.Math.PI
  let disk =
    let n = max (3.0f * 2.0f * pi) (ceil (2.0f * pi * (r * S)))
    let arr = [|0.0f .. 1.0f / n .. 2.0f * pi|] // angular samples
    Array.map (fun v -> PointF (r * cos v, r * sin v)) arr
    |> translate origin
    |> scale S
  let secHand s =
    [|PointF (0.0f, 0.0f); PointF (0.0f, -0.4f)|]
    |> rotate (s * 2.0f * pi / 60.0f)
    |> translate origin
    |> scale S
  let minHand m =
    [|PointF (0.016f, 0.0f); PointF (-0.016f, 0.0f); PointF (0.0f, -0.4f); PointF (0.016f, 0.0f)|]
    |> rotate (m * 2.0f * pi / 60.0f)
    |> translate origin
    |> scale S
  let hourHand h =
    [|PointF (0.016f, 0.0f); PointF (-0.016f, 0.0f); PointF (0.0f, -0.25f); PointF (0.016f, 0.0f)|]
    |> rotate (h * 2.0f * pi / 12.0f)
    |> translate origin
    |> scale S
  let black = new Pen (Color.Black)
  let shape (now : DateTime) : (Pen * (PointF [])) list = 
    let s = single now.Second
    let m = single now.Minute
    let h = single now.Hour
    [ (black, disk); (black, secHand s); (black, minHand m); (black, hourHand h) ]
  let txt (now : DateTime) : string =
    sprintf "%d/%02d/%02d %d:%02d:%02d" now.Year now.Month now.Day now.Hour now.Minute now.Second
  (size, shape, txt)

///////////// Connection //////////////
// Tie view and model together and enter main event loop
let (size, shape, now) = model ()
let run = view size shape now
run ()
