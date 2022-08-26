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
  let hist = Array.create size 0
  let mutable c = Unchecked.defaultof<int>
  while not(reader.EndOfStream) do
    c <- pushForward (reader.Read ())
    if legalIndex size c then
      hist[c] <- hist[c] + 1
  hist

let sampleFromCumulativeProbability cumulative noSamples =
  let rnd = System.Random ()
  let rndArray = Array.init noSamples (fun _ -> rnd.NextDouble ())
  Array.map (lookup cumulative) rndArray

let filename = "randomTextOrder0.fsx"
let noSamples = 200
let histSize = 126 - 32 + 1

let reader = System.IO.File.OpenText filename
let hist = analyzeFile reader histSize intToIdx
reader.Close ()
let idxValue = Array.mapi (fun i v -> (idxToInt i, v)) hist
printfn "%A" idxValue
printfn "%d zeros out of %d elements" (countEqual hist 0) hist.Length
let cumulative = histToCumulativeProbability hist
let rndIdx = sampleFromCumulativeProbability cumulative noSamples
let rndInt = Array.map idxToInt rndIdx
let rndChar = Array.map (fun v -> char v) rndInt
let text = System.String.Concat rndChar // System.String is not the same as String !!!
printfn "%A" text
