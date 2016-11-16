open System
open System.Windows.Forms

let flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel ();
let button1 = new System.Windows.Forms.Button ();
let button2 = new System.Windows.Forms.Button ();
let button3 = new System.Windows.Forms.Button ();
let button4 = new System.Windows.Forms.Button ();
let wrapContentsCheckBox = new System.Windows.Forms.CheckBox ();
let flowTopDownBtn = new System.Windows.Forms.RadioButton ();
let flowBottomUpBtn = new System.Windows.Forms.RadioButton ();
let flowLeftToRight = new System.Windows.Forms.RadioButton ();
let flowRightToLeftBtn = new System.Windows.Forms.RadioButton ();

// 
// button1
// 
button1.Location <- new System.Drawing.Point (3, 3);
button1.Name <- "button1";
button1.TabIndex <- 0;
button1.Text <- "button1";
// 
// button2
// 
button2.Location <- new System.Drawing.Point (84, 3);
button2.Name <- "button2";
button2.TabIndex <- 1;
button2.Text <- "button2";
// 
// button3
// 
button3.Location <- new System.Drawing.Point (3, 32);
button3.Name <- "button3";
button3.TabIndex <- 2;
button3.Text <- "button3";
// 
// button4
// 
button4.Location <- new System.Drawing.Point (84, 32);
button4.Name <- "button4";
button4.TabIndex <- 3;
button4.Text <- "button4";
// 
// wrapContentsCheckBox
// 
wrapContentsCheckBox.Location <- new System.Drawing.Point (46, 162);
wrapContentsCheckBox.Name <- "wrapContentsCheckBox";
wrapContentsCheckBox.TabIndex <- 1;
wrapContentsCheckBox.Text <- "Wrap Contents";
wrapContentsCheckBox.Checked <- true
wrapContentsCheckBox.CheckedChanged.Add (fun _ -> flowLayoutPanel.WrapContents <- wrapContentsCheckBox.Checked)
// 
// flowTopDownBtn
// 
flowTopDownBtn.Location <- new System.Drawing.Point (45, 193);
flowTopDownBtn.Name <- "flowTopDownBtn";
flowTopDownBtn.TabIndex <- 2;
flowTopDownBtn.Text <- "Flow TopDown";
flowTopDownBtn.Checked <- flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
flowTopDownBtn.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- FlowDirection.TopDown);
// 
// flowBottomUpBtn
// 
flowBottomUpBtn.Location <- new System.Drawing.Point (44, 224);
flowBottomUpBtn.Name <- "flowBottomUpBtn";
flowBottomUpBtn.TabIndex <- 3;
flowBottomUpBtn.Text <- "Flow BottomUp";
flowBottomUpBtn.Checked <- flowLayoutPanel.FlowDirection = FlowDirection.BottomUp
flowBottomUpBtn.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- FlowDirection.BottomUp);
// 
// flowLeftToRight
// 
flowLeftToRight.Location <- new System.Drawing.Point (156, 193);
flowLeftToRight.Name <- "flowLeftToRight";
flowLeftToRight.TabIndex <- 4;
flowLeftToRight.Text <- "Flow LeftToRight";
flowLeftToRight.Checked <- flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
flowLeftToRight.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- FlowDirection.LeftToRight);
// 
// flowRightToLeftBtn
// 
flowRightToLeftBtn.Location <- new System.Drawing.Point (155, 224);
flowRightToLeftBtn.Name <- "flowRightToLeftBtn";
flowRightToLeftBtn.TabIndex <- 5;
flowRightToLeftBtn.Text <- "Flow RightToLeft";
flowRightToLeftBtn.Checked <- flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
flowRightToLeftBtn.CheckedChanged.Add (fun _ -> flowLayoutPanel.FlowDirection <- FlowDirection.RightToLeft);
// 
// flowLayoutPanel
// 
flowLayoutPanel.Controls.Add (button1);
flowLayoutPanel.Controls.Add (button2);
flowLayoutPanel.Controls.Add (button3);
flowLayoutPanel.Controls.Add (button4);
flowLayoutPanel.Location <- new System.Drawing.Point (47, 55);
flowLayoutPanel.BorderStyle <- BorderStyle.Fixed3D;
flowLayoutPanel.Name <- "flowLayoutPanel";
flowLayoutPanel.TabIndex <- 0;
flowLayoutPanel.WrapContents <- wrapContentsCheckBox.Checked
// 
// Form1
//
let Form1 = new Form ()
Form1.ClientSize <- new System.Drawing.Size (292, 266);
Form1.Controls.Add (flowRightToLeftBtn);
Form1.Controls.Add (flowLeftToRight);
Form1.Controls.Add (flowBottomUpBtn);
Form1.Controls.Add (flowTopDownBtn);
Form1.Controls.Add (wrapContentsCheckBox);
Form1.Controls.Add (flowLayoutPanel);
Form1.Name <- "Form1";
Form1.Text <- "Form1";
Application.Run Form1
