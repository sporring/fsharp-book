open Gtk

let width, height = 500, 500

//Initialize application
Application.Init()

//Create a window
let myWin = new Window("My first GTK# Application! ");
myWin.Resize(200,200);
myWin.DeleteEvent.Add(fun e -> myWin.Hide(); Application.Quit(); e.RetVal <- true)

//Create a label and put some text in it.
let myLabel = new Label();
myLabel.Text <- "Hello World!!!!";

//Add the label to the form
myWin.Add(myLabel);

//Show all
myWin.ShowAll()

//Run application
Application.Run()
