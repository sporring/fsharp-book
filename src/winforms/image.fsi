module Image
/// A set of functions for image processing

/// <summary>Convert a System.Drawing.Bitmap into a gray value Array2D.</summary>
/// <param name="I">The original image.</param>
/// <returns>A new Array2D with the same size is I, but where the RGB colorvalue has been replaced by their average value.</returns>
val bitmap2GrayArray2D : I:System.Drawing.Bitmap -> float [,]

/// <summary>Convert a gray value Array2D into a System.Drawing.Bitmap.</summary>
/// <param name="I">The original image.</param>
/// <returns>A new System.Drawing.Bitmap RGB image, where R, G, and B have identical value.</returns>
val grayArray2D2Bitmap : I:float [,] -> System.Drawing.Bitmap

/// <summary>Find the maximum value of an image.</summary>
/// <param name="I">An image.</param>
/// <returns>The maximum value.</returns>
val array2dMax : I:float [,] -> float

/// <summary>Find the minimum value of an image.</summary>
/// <param name="I">An image.</param>
/// <returns>The minimum value.</returns>
val array2dMin : I:float [,] -> float

/// <summary>Sum all values of an image.</summary>
/// <param name="I">An image.</param>
/// <returns>The sum.</returns>
val array2dSum : float [,] -> float

/// <summary>Linearly scale an image intensities, such that the resulting min and max are newMin and newMax.</summary>
/// <param name="I">An image.</param>
/// <param name="newMin">The desired minimum.</param>
/// <param name="newMax">The desired maximum.</param>
/// <returns>A new image.</returns>
val normalize : I:float [,] * newMin:float * newMax:float -> float [,]

/// <summary>Calculate the gradient vector w.r.t. the image index coordinates in all positions.</summary>
/// <param name="I">An image.</param>
/// <returns>A tupple of images, (Ix, Iy), where (Ix.[i,j], Iy.[i,j]) are the derivative along the first and second index directions respectively at location i, j.</returns>
val d : I:float [,] -> float [,] * float [,]

/// <summary>Calculate the gradient length in every position.</summary>
/// <param name="I">An image.</param>
/// <returns>A new image containing the gradient in each location.</returns>
val grad : Ix:float [,] * Iy:float [,] -> float [,]

/// <summary>Convolve 2 images.</summary>
/// <param name="I">An image.</param>
/// <param name="K">A kernel (also an image).</param>
/// <returns>A new image, which is the convolution of I and K.</returns>
val convolve : I:float [,] * K:float [,] -> float [,]

/// <summary>The image of a 2 dimensional gaussian kernel.</summary>
/// <param name="width">The resulting width (first coordinate).</param>
/// <param name="height">The resulting height (second coordinate).</param>
/// <param name="sigma">The standard devation of the gaussina.</param>
/// <returns>An image of the gaussian.</returns>
val gauss : width:int * height:int * sigma:float -> float [,]
