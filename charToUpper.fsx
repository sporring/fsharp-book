let charToUpper c =
  if ((int 'a') <= c) && (c <= (int 'z')) then
    c - (int 'a') + (int 'A')
  else
    c
