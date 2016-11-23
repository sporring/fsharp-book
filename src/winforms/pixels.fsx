/// Open a window using winforms in Mono. The program opens a window
/// and draws a bitmap of black and white squares.
///
/// How to compile:
/// <code>
/// fsharpc pixels.fsx
/// </code>
///
/// Author: Jon Sporring.
/// Date: 2015/11/29

let display(aTitle: string, aBitMap : bool [ , ], aColor:System.Drawing.Color) =
    let brush = new System.Drawing.SolidBrush (aColor)
    let pixelWidth = 10
    let pixeHeight = 10
    let bitMapWidth = Collections.Array2D.length1 aBitMap
    let bitMapHeight = Collections.Array2D.length2 aBitMap
    let sz = new System.Drawing.Size (pixelWidth, pixeHeight)
    let draw (g:System.Drawing.Graphics) =
      for i = 0 to bitMapWidth - 1 do
        for j = 0 to bitMapHeight - 1 do
          if aBitMap.[i,j] then
            let p = System.Drawing.Point ( i*pixelWidth, j*pixeHeight )
            let rect = new System.Drawing.Rectangle (p, sz)
            g.FillRectangle (brush, rect)
    let panel = new System.Windows.Forms.Panel (Dock = System.Windows.Forms.DockStyle.Fill)
    let winSize = System.Drawing.Size (bitMapWidth * pixelWidth, bitMapHeight * pixeHeight)
    let win = new System.Windows.Forms.Form (Text = aTitle, ClientSize = winSize, MaximizeBox = false, MinimizeBox = false)

    panel.Paint.Add (fun e -> draw (e.Graphics))
    win.Controls.Add panel
    System.Windows.Forms.Application.Run win

let width = 30;
let height = 55;
let rnd = System.Random ()    
let arrayOfBools = Collections.Array2D.init<bool> width height (fun i j -> (rnd.Next(2) > 0))
display("A bitmap", arrayOfBools, System.Drawing.Color.Black)
