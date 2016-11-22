open System.Windows.Forms
open System.Drawing

let Form1 = new Form ()
let pBar1 = new ProgressBar ()

// customize window
Form1.ClientSize <- new Size (250,50)
// customize the ProgressBar control.
pBar1.Minimum <- 1
pBar1.Maximum <- 10
pBar1.Value <- 1
pBar1.Step <- 1
pBar1.Width <- 200

// Simulate that some process has caused the progress bar to increase 3 times
for i = pBar1.Minimum to 6 do
  pBar1.PerformStep()

// Add progress bar to window and give control to 
Form1.Controls.Add pBar1
Application.Run Form1
