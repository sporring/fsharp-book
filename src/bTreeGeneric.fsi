module bTree

type bTree<'a>

/// Create a tree with one value and no children
val create: 'a -> bTree<'a>
/// Replace the value in the root of t with v
val replaceValue: v: 'a -> t: bTree<'a> -> bTree<'a>
/// replace t's left child with c
val replaceLeft: c: bTree<'a> -> t: bTree<'a> -> bTree<'a>
/// replace t's right child with c
val replaceRight: c: bTree<'a> -> t: bTree<'a> -> bTree<'a>
/// Traverse the tree in prefix order.
val prefix: bTree<'a> -> 'a list
/// Traverse the tree in infix order.
val infix: bTree<'a> -> 'a list
/// Traverse the tree in postfix order.
val postfix: bTree<'a> -> 'a list
