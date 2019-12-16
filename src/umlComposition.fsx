type leg () =
  member this.move = "moving"
type dog () =
  let _leg = List.init 4 (fun e -> leg ())

let bestFriend = dog ()
