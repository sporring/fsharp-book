// Explicit references has the advantage that
//   intellisense with libraries,
//   fsharpc does not require linking when compiling,
//   but is installation specific
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/gtk-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/glib-sharp.dll"
#r @"/Library/Frameworks/Mono.framework/Versions/Current/lib/mono/gtk-sharp-2.0/atk-sharp.dll"

open Gtk

// Global states
let mutable cancellationSource = new System.Threading.CancellationTokenSource() // placeholder, not used
let mutable ithPrime = (0,2); // present prime number to display
let mutable compCount = 0; // Number of asynchronous processes started

// Calculate primes using eratosthenes sieve
let comp (update : unit -> unit) = async {
    printfn "Starting"
    use! holder = Async.OnCancel(fun () ->     
        printfn "Stopping"
        compCount <- compCount - 1)
    compCount <- compCount + 1
    let s = Seq.initInfinite (fun i -> i+2)
    let sieve n = Seq.filter (fun v -> v%n <> 0)
    let primes = Seq.unfold (fun s -> let h = Seq.head s in Some(h, sieve h (Seq.tail s))) s
    while true do
        ithPrime <- (1 + fst ithPrime, Seq.item (1+fst ithPrime) primes)
        update ()
        do! Control.Async.Sleep 10 // Allow for other async processes and cancel
}

//Initialize application
Application.Init()
//Create a window
let win = new Window ("");
let vbox = new VBox ()
let hbox = new HBox ()
let primeText = new Label ()
let stateText = new Label()  
let startButton = new Button ()
let stopButton = new Button ()

//Create buttons and a label
win.Add vbox
vbox.Add primeText
vbox.Add stateText
vbox.Add hbox
hbox.Add startButton
hbox.Add stopButton

win.DeleteEvent.Add (fun e -> win.Hide(); Application.Quit(); e.RetVal <- true)
primeText.Text <- "No prime calculated"
let update () = 
  stateText.Text <- "State: " + (string)compCount
  primeText.Text <- "prime(" + (string)(fst ithPrime) + ") = " + (string)(snd ithPrime)
startButton.Label <- "Start"
startButton.Clicked.Add (fun _ -> 
  if compCount = 0 then 
    cancellationSource <- new System.Threading.CancellationTokenSource()
    Control.Async.Start (comp update, cancellationSource.Token)
  )
stopButton.Label <- "Stop"
stopButton.Clicked.Add (fun _ -> 
  if compCount > 0 then 
    cancellationSource.Cancel()
    cancellationSource.Dispose()
    )

//Show all
win.ShowAll()

//Run application
Application.Run()