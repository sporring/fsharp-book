// Choose some points and a color
let Points =
  [|System.Drawing.Point (0,0);
   System.Drawing.Point (10,170);
   System.Drawing.Point (320,20);
   System.Drawing.Point (0,0)|]
let penColor = System.Drawing.Color.Black
// Create window and setup drawing function
let pen = new System.Drawing.Pen (penColor)
let win = new System.Windows.Forms.Form ()
win.Text <- "A triangle"
win.Paint.Add (fun e -> e.Graphics.DrawLines (pen, Points))
// Start the event-loop. Use "win.Show()" on Microsoft Windows instead.
System.Windows.Forms.Application.Run win
