let wLst = ["Many";"years";"ago";"there";"was";"an";"Emperor"]
let wLen = List.map (fun (w: string) -> (w,w.Length)) wLst
let maxWLen acc elm = if snd acc > snd elm then acc else elm
let longest = List.fold maxWLen ("",0) wLen
printfn "The longest word is %A" longest
