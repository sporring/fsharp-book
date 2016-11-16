open System
open System.Drawing
open System.Windows.Forms

// Initialize a form containing a panel, textbox, and a label
let form = new Form ()
let panel = new Panel();
let textBox = new TextBox();
let label = new Label();

// Customize the Form.
form.Text <- "A panel";
form.ClientSize <- new Size(400, 300);

// Customize the Panel control.
panel.Location <- new Point(56,72);
panel.Size <- new Size(264, 152);
panel.BorderStyle <- BorderStyle.Fixed3D;

// Customize the Label and TextBox controls.
label.Location <- new Point(16,16);
label.Text <- "label1";
label.Size <- new Size(104, 16);
textBox.Location <- new Point(16,32);
textBox.Text <- "Initial text";
textBox.Size <- new Size(152, 20);

// Add panel to form and label and textBox to panel.
form.Controls.Add(panel);
panel.Controls.Add(label);
panel.Controls.Add(textBox);

// Give control to WinForms' event loop
Application.Run form
