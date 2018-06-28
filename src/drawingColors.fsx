// open namespace for brevity
open System.Drawing
// Define a color from ARGB
let c = Color.FromArgb (0xFF, 0x7F, 0xFF, 0xD4) //Aquamarine
printfn "The color %A is (%x, %x, %x, %x)" c c.A c.R c.G c.B
// Define a list of named colors
let colors =
  [Color.Red; Color.Green; Color.Blue;
   Color.Black; Color.Gray; Color.White]
for col in colors do
  printfn "The color %A is (%x, %x, %x, %x)" col col.A col.R col.G col.B
