open System;
open System.Drawing;
open System.Windows.Forms;

let Form1 = new Form ()

let textBox1 = new TextBox();
let trackBar1 = new TrackBar();

// TextBox for TrackBar.Value update.
textBox1.Location <- new Point(240, 16);
textBox1.Size <- new Size(48, 20);

// Set up how the form should be displayed and add the controls to the form.
Form1.ClientSize <- new Size(296, 62);
Form1.Controls.AddRange [| textBox1; trackBar1 |];
Form1.Text <- "TrackBar Example";

// Set up the TrackBar.
trackBar1.Location <- new Point(8, 8);
trackBar1.Size <- new Size(224, 45);
let trackBar1_Scroll (e : EventArgs) = 
  textBox1.Text <- string trackBar1.Value;
trackBar1.Scroll.Add trackBar1_Scroll;

// The Maximum property sets the value of the track bar when
// the slider is all the way to the right.
trackBar1.Maximum <- 30;

// The TickFrequency property establishes how many positions
// are between each tick-mark.
trackBar1.TickFrequency <- 5;

// The LargeChange property sets how many positions to move
// if the bar is clicked on either side of the slider.
trackBar1.LargeChange <- 3;

// The SmallChange property sets how many positions to move
// if the keyboard arrows are used to move the slider.
trackBar1.SmallChange <- 2;

Application.Run Form1;
