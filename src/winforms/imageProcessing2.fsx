let display (aTitle: string, I : System.Drawing.Bitmap) =
  let winSize = System.Drawing.Size (I.Width, I.Height)
  let win = new System.Windows.Forms.Form (Text = aTitle, ClientSize = winSize, MaximizeBox = false, MinimizeBox = false)
  let pb = new System.Windows.Forms.PictureBox (Image = I, Size = I.Size)
  win.Controls.Add(pb)
  win.Show();
  win
  
let C = new System.Drawing.Bitmap ("Barbara.jpg")
display ("The original image", C) |> ignore

let I = Image.bitmap2GrayArray2D C
printfn "I : %g %g" (Image.array2dMin I) (Image.array2dMax I)
display ("The gray version", Image.grayArray2D2Bitmap I) |> ignore

let dI = Image.grad (Image.d I)
printfn "dI : %g %g" (Image.array2dMin dI) (Image.array2dMax dI)
display ("The gradient of the gray image", Image.grayArray2D2Bitmap dI) |> ignore
display ("The normalized gradient", Image.grayArray2D2Bitmap (Image.normalize (dI, 0.0, 255.0))) |> ignore

for sigma in [ 1.0; 5.0 ] do
  printfn "sigma = %f" sigma
  let G = Image.gauss (int (4.0 * sigma + 1.0), int (4.0 * sigma + 1.0), sigma)
  printfn "G : %g %g %g" (Image.array2dMin G) (Image.array2dMax G) (Image.array2dSum G)
  let J = Image.convolve (I, G)
  printfn "J : %g %g" (Image.array2dMin J) (Image.array2dMax J)
  display (sprintf "The smoothed gray image (sigma = %f)" sigma, Image.grayArray2D2Bitmap J) |> ignore

  let dJ = Image.grad (Image.d J)
  printfn "dJ : %g %g" (Image.array2dMin dJ) (Image.array2dMax dJ)
  display (sprintf "The normalized gradient of the smoothed image (sigma = %f)" sigma, Image.grayArray2D2Bitmap (Image.normalize (dJ, 0.0, 255.0))) |> ignore

printfn "Press crtl-c to quit"
System.Windows.Forms.Application.Run ()
