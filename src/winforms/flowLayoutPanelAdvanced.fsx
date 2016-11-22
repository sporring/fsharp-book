open System.Windows.Forms
open System.Drawing
open System

let win = new Form ()
let mainPanel = new FlowLayoutPanel ()
let mainPanelBorder = 5
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
// changing border style changes ClientSize
panel.BorderStyle <- BorderStyle.Fixed3D
let width = panel.ClientSize.Width / 2 - panel.Margin.Left - panel.Margin.Right
for (btn, txt, dir) in radioButtonLst do
  btn.Width <- width
  panel.Controls.Add (btn)

mainPanel.Location <- new Point (mainPanelBorder, mainPanelBorder)
mainPanel.BorderStyle <- BorderStyle.Fixed3D
mainPanel.Controls.Add flowLayoutPanel
mainPanel.Controls.Add wrapContentsCheckBox
mainPanel.Controls.Add panel

// customize window, add controls, and start event-loop
win.ClientSize <- new Size (220, 256)
let windowResize _ =
  let size = win.DisplayRectangle.Size
  mainPanel.Size <- new Size (size.Width - 2 * mainPanelBorder, size.Height - 2 * mainPanelBorder)
windowResize ()
win.Resize.Add windowResize
win.Controls.Add mainPanel
win.Text <- "Advanced Flowlayout"
Application.Run win
