let toHist i =
  i - (int ' ')

let fromHist i =
  i + (int ' ')

let analyzeFile (reader : System.IO.StreamReader) size pushForward =
  let hist = Array.create size 0
  let mutable c = Unchecked.defaultof<int>
  while not(reader.EndOfStream) do
    c <- pushForward (reader.Read ())
    if (0 <= c) && (c <= hist.Length - 1) then
      hist.[c] <- hist.[c] + 1
  hist

let sampleFromHist hist n pullBack =
  let appendSum (acc : float array) (elem : int) =
    let sum =
      if acc.Length = 0 then
        float elem
      else
        acc.[acc.Length-1] + (float elem)
    Array.append acc [| sum |]

  let castToFloat acc elem = Array.append acc [| float elem |]

  let normalizeProbability k v = v/k

  let lookup (hist : float array) (v : float) =
    Array.findIndex (fun h -> h > v) hist

  let castToHistIndex cumProbability (acc : int array) (elem : float) =
    Array.append acc [| lookup cumProbability elem |]

  let castToString (acc : string) (elem : int) =
    acc + (string (char (pullBack elem)))

  let cumSum = Array.fold appendSum Array.empty<float> hist
  let norm = normalizeProbability cumSum.[cumSum.Length - 1]
  let cumProbability = Array.map norm cumSum
  let rnd = System.Random ()
  let rndArray = Array.init n (fun _ -> rnd.NextDouble ())
  let rndIdx = Array.fold (castToHistIndex cumProbability) Array.empty<int> rndArray

  Array.fold castToString "" rndIdx

let countEqual A v =
  Array.fold (fun acc elem -> if elem = v then acc+1 else acc) 0 A;;
  
let filename = "histogram0.fsx"
let n = 200
let histSize = 126 - 32 + 1

let reader = System.IO.File.OpenText filename
let hist = analyzeFile reader histSize toHist
let pair = Array.zip (Array.map fromHist [| 0 .. hist.Length - 1 |]) hist
printfn "%A" pair
printfn "%d zeros" (countEqual hist 0)
let text = sampleFromHist hist n fromHist
printfn "%A" text
