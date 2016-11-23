let display (aTitle: string, I : System.Drawing.Bitmap, J : System.Drawing.Bitmap) =
  let width  = I.Width + J.Height
  let height  = max I.Height J.Height
  let winSize = System.Drawing.Size (width, height)
  let win = new System.Windows.Forms.Form (Text = aTitle, ClientSize = winSize, MaximizeBox = false, MinimizeBox = false)

  let pbLoc = new System.Drawing.Point (0, 0)
  let pb = new System.Windows.Forms.PictureBox (Image = I, Size = I.Size, Location = pbLoc)
  win.Controls.Add(pb)

  let pb2Loc = new System.Drawing.Point (I.Width, 0)
  let pb2 = new System.Windows.Forms.PictureBox (Image = J, Size = J.Size, Location = pb2Loc )
  win.Controls.Add(pb2)

  System.Windows.Forms.Application.Run win
  
let C = new System.Drawing.Bitmap ("Barbara.jpg")
let I = Image.bitmap2GrayArray2D C
printfn "I : %g %g" (Image.array2dMin I) (Image.array2dMax I)
display ("An image and its gray version", C, Image.grayArray2D2Bitmap I)

let dI = Image.grad (Image.d I)
printfn "dI : %g %g" (Image.array2dMin dI) (Image.array2dMax dI)
display ("A gray image and its gradient", Image.grayArray2D2Bitmap I, Image.grayArray2D2Bitmap dI)
display ("A gray image and its normalized gradient", Image.grayArray2D2Bitmap (Image.normalize (I, 0.0, 255.0)), Image.grayArray2D2Bitmap (Image.normalize (dI, 0.0, 255.0)))

let sigma = 1.0
let G = Image.gauss (int (4.0 * sigma + 1.0), int (4.0 * sigma + 1.0), sigma)
printfn "G : %g %g %g" (Image.array2dMin G) (Image.array2dMax G) (Image.array2dSum G)
let J = Image.convolve (I, G)
printfn "J : %g %g" (Image.array2dMin J) (Image.array2dMax J)
display ("A gray image and its smoothed version", Image.grayArray2D2Bitmap I, Image.grayArray2D2Bitmap J)

let dJ = Image.grad (Image.d J)
printfn "dJ : %g %g" (Image.array2dMin dJ) (Image.array2dMax dJ)
display ("A smoothed image and its normalized gradient", Image.grayArray2D2Bitmap (Image.normalize (J, 0.0, 255.0)), Image.grayArray2D2Bitmap (Image.normalize (dJ, 0.0, 255.0)))

let sigma2 = 5.0
let G2 = Image.gauss (int (4.0 * sigma2 + 1.0), int (4.0 * sigma2 + 1.0), sigma2)
printfn "G2 : %g %g %g" (Image.array2dMin G2) (Image.array2dMax G2) (Image.array2dSum G2)
let J2 = Image.convolve (I, G2)
printfn "J2 : %g %g" (Image.array2dMin J2) (Image.array2dMax J2)
display ("A gray image and its smoothed version", Image.grayArray2D2Bitmap I, Image.grayArray2D2Bitmap J2)

let dJ2 = Image.grad (Image.d J2)
printfn "dJ2 : %g %g" (Image.array2dMin dJ2) (Image.array2dMax dJ2)
display ("A smoothed image and its normalized gradient", Image.grayArray2D2Bitmap (Image.normalize (J2, 0.0, 255.0)), Image.grayArray2D2Bitmap (Image.normalize (dJ2, 0.0, 255.0)))
