open System.Windows.Forms
open System.Drawing

///////////// WinForm specifics /////////////
/// Setup a window form and return function to activate
let view (sz : Size) (shapes : (Pen * (Point [])) list) : (unit -> unit) =
  let win = new System.Windows.Forms.Form ()
  win.ClientSize <- sz
  let paint (e : PaintEventArgs) ((p, pts) : (Pen * (Point []))) : unit = 
    e.Graphics.DrawLines (p, pts)
  win.Paint.Add (fun e -> List.iter (paint e) shapes)
  fun () -> Application.Run win // function as return value

///////////// Model /////////////
// Turtle commands, type definitions must be in outer most scope
type Command = F | L | R
type Turtle = {x : float; y : float; d : float}

// A black Hilbert curve using winform primitives for brevity
let model () : Size * ((Pen * (Point [])) list) = 
  /// Hilbert recursion production rules
  let rec A n : Command list =
    if n > 0 then
      [L]@B (n-1)@[F; R]@A (n-1)@[F]@A (n-1)@[R; F]@B (n-1)@[L]
    else
      []
  and B n : Command list = 
    if n > 0 then
      [R]@A (n-1)@[F; L]@B (n-1)@[F]@B (n-1)@[L; F]@A (n-1)@[R]
    else
      []

  /// Convert a command to a turtle record and prepend to a list
  let addRev (lst : Turtle list) (cmd : Command) (len : float) : Turtle list =
    let toInt = int << round
    match lst with
      | t::rest ->
        match cmd with
          | L -> {t with d = t.d + 3.141592/2.0}::rest // turn left
          | R -> {t with d = t.d - 3.141592/2.0}::rest // turn right
          | F -> {t with x = t.x + len * cos t.d;
                         y = t.y + len * sin t.d}::lst // forward
      | _ -> failwith "Turtle list must be non-empty."

  let maxPoint (p1 : Point) (p2 : Point) : Point =
    Point (max p1.X p2.X, max p1.Y p2.Y)

  // Calculate commands for a specific order
  let curve = A 5
  // Convert commands to point array
  let initTrtl = {x = 0.0; y = 0.0; d = 0.0}
  let len = 20.0
  let line =
    // Convert command list to reverse turtle list
    List.fold (fun acc elm -> addRev acc elm len) [initTrtl] curve
    // Reverse list
    |> List.rev
    // Convert turtle list to point list
    |> List.map (fun t -> Point (int (round t.x), int (round t.y)))
    // Convert point list to point array
    |> List.toArray
  let black = new Pen (Color.FromArgb (0, 0, 0))
  // Set size to as large as shape
  let minVal = System.Int32.MinValue
  let maxPoint = Array.fold maxPoint (Point (minVal, minVal)) line
  let size = Size (maxPoint.X + 1, maxPoint.Y + 1)
  // return shapes as singleton list
  (size, [(black, line)])

///////////// Connection //////////////
// Tie view and model together and enter main event loop
let (size, shapes) = model ()
let run = view size shapes
run ()
