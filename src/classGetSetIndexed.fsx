type aClass (size : int) = 
  let arr = Array.create<int> size 0
  member this.Item
    with get (ind : int) = arr[ind]
    and set (ind : int) (p : int) = arr[ind] <- p

let a = aClass (3) 
printfn "%A" a
printfn "%d %d %d" a[0] a[1] a[2]
a[1] <- 3
printfn "%d %d %d" a[0] a[1] a[2]
