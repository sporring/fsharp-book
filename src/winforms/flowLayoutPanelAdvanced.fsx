open System.Windows.Forms
open System.Drawing

let mainPanel = new FlowLayoutPanel ()
let flowLayoutPanel = new FlowLayoutPanel ()
let buttonLst =
  [(new Button (), "Button0");
   (new Button (), "Button1");
   (new Button (), "Button2");
   (new Button (), "Button3")]
let wrapContentsCheckBox = new CheckBox ()
let panel = new FlowLayoutPanel ()
let initiallyWrapped = true
let radioButtonLst =
  [(new RadioButton (), "TopDown", FlowDirection.TopDown);
   (new RadioButton (), "BottomUp", FlowDirection.BottomUp);
   (new RadioButton (), "LeftToRight", FlowDirection.LeftToRight);
   (new RadioButton (), "RightToLeft", FlowDirection.RightToLeft)]

// customize buttons
for (btn, txt) in buttonLst do
  btn.Text <- txt

// customize radio buttons
for (btn, txt, dir) in radioButtonLst do
  btn.Text <- txt
  btn.Checked <- flowLayoutPanel.FlowDirection = dir
  btn.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- dir)

// customize flowLayoutPanel
for (btn, txt) in buttonLst do
  flowLayoutPanel.Controls.Add btn
flowLayoutPanel.BorderStyle <- BorderStyle.Fixed3D
flowLayoutPanel.WrapContents <- initiallyWrapped

// customize wrapContentsCheckBox
wrapContentsCheckBox.Text <- "Wrap Contents"
wrapContentsCheckBox.Checked <- initiallyWrapped
wrapContentsCheckBox.CheckedChanged.Add (fun _ -> flowLayoutPanel.WrapContents <- wrapContentsCheckBox.Checked)

// customize panel
//panel.Controls.Add (wrapContentsCheckBox)
for (btn, txt, dir) in radioButtonLst do
  btn.Width <- 75
  panel.Controls.Add (btn)
panel.BorderStyle <- BorderStyle.Fixed3D

mainPanel.Location <- new Point (5, 5)
mainPanel.BorderStyle <- BorderStyle.Fixed3D
mainPanel.Size <- new Size (220, 350)
mainPanel.Controls.Add flowLayoutPanel
mainPanel.Controls.Add (wrapContentsCheckBox)
mainPanel.Controls.Add panel

// Create a window, add controlse, and start event-loop
let win = new Form ()
win.ClientSize <- new Size (320, 420)
win.Controls.Add mainPanel
win.Text <- "A Flowlayout Example"
Application.Run win
