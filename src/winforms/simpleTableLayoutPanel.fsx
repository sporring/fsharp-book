open System.Windows.Forms
open System.Drawing
open System

let win = new Form ()
let panel = new TableLayoutPanel ()
let controlLst =
  [(new Label (), "One", Color.Green);
   (new Label (), "Two", Color.Blue);
   (new Label (), "Three", Color.Red);
   (new Label (), "Four", Color.Yellow)]

// customize panel
panel.Dock <- DockStyle.Fill
panel.BorderStyle <- BorderStyle.Fixed3D
panel.ColumnCount <- 2

// customize buttons and add to panel
for (ctrl, txt, col) in controlLst do
  ctrl.Margin <- Padding 0
  ctrl.Text <- txt
  ctrl.BackColor <- col
  panel.Controls.Add ctrl

// customize window, add controls, and start event-loop
win.Text <- "TablelayoutPanel"
win.ClientSize <- new Size (220, 100)
win.Controls.Add panel
Application.Run win
