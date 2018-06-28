open System.Windows.Forms
open System.Drawing
open System

/// A button event
let buttonClicked (e : EventArgs) =
  MessageBox.Show "You clicked the button." |> ignore

// Create a button
let button = new Button ()
button.Size <- new Size (100, 40)
button.Location <- new Point (20, 20)
button.Text <- "Click me"
button.Click.Add buttonClicked

// Create a window and add button
let win = new Form ()
win.Controls.Add button

// Start the event-loop.
Application.Run win
