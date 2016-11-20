open System.Windows.Forms
open System.Drawing

let flowLayoutPanel = new FlowLayoutPanel ()
let buttonLst =
  [(new Button (), "Button0");
   (new Button (), "Button1");
   (new Button (), "Button2");
   (new Button (), "Button3")]
let panel = new Panel ()
let wrapContentsCheckBox = new CheckBox ()
let initiallyWrapped = true
let radioButtonLst =
  [(new RadioButton (), (3, 34), "TopDown", FlowDirection.TopDown);
   (new RadioButton (), (3, 62), "BottomUp", FlowDirection.BottomUp);
   (new RadioButton (), (111, 34),"LeftToRight", FlowDirection.LeftToRight);
   (new RadioButton (), (111, 62),"RightToLeft", FlowDirection.RightToLeft)]

// customize buttons
for (btn, txt) in buttonLst do
  btn.Text <- txt

// customize wrapContentsCheckBox
wrapContentsCheckBox.Location <- new Point (3, 3)
wrapContentsCheckBox.Text <- "Wrap Contents"
wrapContentsCheckBox.Checked <- initiallyWrapped
wrapContentsCheckBox.CheckedChanged.Add (fun _ -> flowLayoutPanel.WrapContents <- wrapContentsCheckBox.Checked)

// customize radio buttons
for (btn, loc, txt, dir) in radioButtonLst do
  btn.Location <- new Point (fst loc, snd loc)
  btn.Text <- txt
  btn.Checked <- flowLayoutPanel.FlowDirection = dir
  btn.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- dir)

// customize flowLayoutPanel
for (btn, txt) in buttonLst do
  flowLayoutPanel.Controls.Add btn
flowLayoutPanel.Location <- new Point (47, 55)
flowLayoutPanel.BorderStyle <- BorderStyle.Fixed3D
flowLayoutPanel.WrapContents <- initiallyWrapped

// customize panel
panel.Controls.Add (wrapContentsCheckBox)
for (btn, loc, txt, dir) in radioButtonLst do
  panel.Controls.Add (btn)
panel.Location <- new Point (47, 190)
panel.BorderStyle <- BorderStyle.Fixed3D

// Create a window, add controlse, and start event-loop
let win = new Form ()
win.ClientSize <- new Size (302, 356)
win.Controls.Add flowLayoutPanel
win.Controls.Add panel
win.Text <- "A Flowlayout Example"
Application.Run win
