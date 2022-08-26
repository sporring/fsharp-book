let histToCumulativeProbability hist = 
  let appendSum (acc : float array) (elem : int) =
    let sum =
      if acc.Length = 0 then
        float elem
      else
        acc[acc.Length-1] + (float elem)
    Array.append acc [| sum |]

  let normalizeProbability k v = v/k

  let cumSum = Array.fold appendSum Array.empty<float> hist
  if cumSum[cumSum.Length - 1] > 0.0 then
    Array.map (normalizeProbability cumSum[cumSum.Length - 1]) cumSum
  else
    Array.create cumSum.Length (1.0 / (float cumSum.Length))

let lookup (hist : float array) (v : float) =
  Array.findIndex (fun h -> h > v) hist

let countEqual A v =
  Array.fold (fun acc elem -> if elem = v then acc+1 else acc) 0 A

let intToIdx i = i - (int ' ')

let idxToInt i = i + (int ' ')

let legalIndex size idx =
  (0 <= idx) && (idx <= size - 1)

let analyzeFile (reader : System.IO.StreamReader) size pushForward =
  let hist = Array2D.create size size 0
  let mutable c1 = Unchecked.defaultof<int>
  let mutable c2 = Unchecked.defaultof<int>
  let mutable nRead = 0
  while not(reader.EndOfStream) do
    c2 <- pushForward (reader.Read ())
    if legalIndex size c2 then
      nRead <- nRead + 1
      if nRead >= 2 then
        hist[c1,c2] <- hist[c1,c2] + 1
      c1 <- c2;
  hist

let Array2DToArray (arr : 'T [,]) = arr |> Seq.cast<'T> |> Seq.toArray

let Array2DOfArray (a : 'T []) = Array2D.init 1 a.Length (fun i j -> a[j])

let hist2DToCumulativeProbability hist =
  let rows = Array2D.length1 hist
  let cols = Array2D.length2 hist
  let cumulative = Array2D.zeroCreate<float> rows cols
  for i = 0 to rows - 1 do
    let histi = Array2DOfArray (histToCumulativeProbability hist[i,*])
    Array2D.blit histi 0 0 cumulative i 0 1 cols
  cumulative

let marginal (hist : int [,]) =
  let rows = Array2D.length1 hist
  let sum = Array.zeroCreate rows
  for i = 0 to rows - 1 do
    sum[i] <- Array.sum hist[i,*]
  sum

let sampleFromCumulativeProbability (cumulative : float [,]) (margCumulative : float array) noSamples =
  let rnd = System.Random ()
  let samples = Array.zeroCreate<int> noSamples
  let mutable v = rnd.NextDouble ()
  let mutable i = Unchecked.defaultof<int>
  samples[0] <- lookup margCumulative v
  for n = 1 to noSamples - 1 do
    v <- rnd.NextDouble ()
    i <- samples[n - 1]
    samples[n] <- lookup cumulative[n, *] v
  samples  

let filename = "randomTextOrder0.fsx"
let noSamples = 200
let histSize = 126 - 32 + 1

let reader = System.IO.File.OpenText filename
let hist = analyzeFile reader histSize intToIdx
reader.Close ()
let idxValue = Array2D.mapi (fun i j v -> (idxToInt i, idxToInt j, v)) hist
printfn "%A"  (Array2DToArray idxValue)
printfn "%d zeros out of %d elements" (countEqual (Array2DToArray hist) 0) hist.Length
let margHist = marginal hist;
let margCumulative = histToCumulativeProbability margHist
let cumulative = hist2DToCumulativeProbability hist
(*
let rndIdx = sampleFromCumulativeProbability cumulative margCumulative noSamples
let rndInt = Array.map idxToInt rndIdx
let rndChar = Array.map (fun v -> char v) rndInt
let text = System.String.Concat rndChar // System.String is not the same as String !!!
printfn "%A" text
*)
