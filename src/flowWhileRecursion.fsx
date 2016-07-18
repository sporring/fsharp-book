let rec prt a b =
  if a <= b then
    printf "%d " a
    prt (a + 1) b
  else
    printf "\n"
prt 1 5
