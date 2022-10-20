module bTree

type bTree<'a>

/// Create a tree with one value and no children
val create: 'a -> bTree<'a>
/// replace t's left child with c
val replaceLeft: c: bTree<'a> -> t: bTree<'a> -> bTree<'a>
/// replace t's right child with c
val replaceRight: c: bTree<'a> -> t: bTree<'a> -> bTree<'a>
/// retrieve the value of the root of m
val retrieveValue: t: bTree<'a> -> 'a
/// retrieve the left child
val tryRetrieveLeft: t: bTree<'a> -> bTree<'a> option
/// retrieve the right child
val tryRetrieveRight: t: bTree<'a> -> bTree<'a> option
/// Traverse the tree in infix order.
val infix: bTree<'a> -> 'a list
