// Explicit references has the advantage that
//   intellisense with libraries,
//   fsharpc does not require linking when compiling,
//   but is installation specific
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/gtk-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/glib-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/atk-sharp.dll"

open Gtk

let worker = new System.ComponentModel.BackgroundWorker()
let mutable run = false;

let s = Seq.initInfinite (fun i -> i+2)
let sieve n = Seq.filter (fun v -> v%n <> 0)
let primes = Seq.unfold (fun s -> let h = Seq.head s in Some(h, sieve h (Seq.tail s))) s
let mutable ithPrime = (0,2); // present prime number to display

let startFct _ =
  run <- true
  if not worker.IsBusy then worker.RunWorkerAsync()

let stopFct _ =
  run <- false

let workFct _ =
  ithPrime <- (1 + fst ithPrime, Seq.item (1+fst ithPrime) primes)

let text () =
  "prime(" + (string)(fst ithPrime) + ") = " + (string)(snd ithPrime)

//Initialize application
Application.Init()
//Create a window
let win = new Window ("");
let box = new VBox ()
let hbox = new HBox ()
let primeText = new Label ()
let startButton = new Button ()
let stopButton = new Button ()

//Create buttons and a label
win.Add box
box.Add primeText
box.Add hbox
hbox.Add startButton
hbox.Add stopButton

win.DeleteEvent.Add (fun e -> win.Hide(); Application.Quit(); e.RetVal <- true)
primeText.Text <- "No prime calculated"
startButton.Label <- "Start"
startButton.Clicked.Add startFct
stopButton.Label <- "Stop"
stopButton.Clicked.Add stopFct

worker.DoWork.Add workFct
worker.RunWorkerCompleted.Add (fun _ -> primeText.Text <- text (); if run then worker.RunWorkerAsync())

//Show all
win.ShowAll()

//Run application
Application.Run()