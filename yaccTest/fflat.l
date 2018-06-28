%{
#include <stdio.h>
#include "fflat.tab.h"
/* See http://www.lysator.liu.se/c/ANSI-C-grammar-l.html and http://dinosaur.compilertools.net/lex/index.html */
%}
D			[0-9]
L			[a-zA-Z_]
B			[01]
O			[0-7]
H			[a-fA-F0-9]
E			[Ee][+-]?{D}+
IS			(y|uy|s|us|u|L|UL|I)
FS                      (f|m)
char                    \'[^\']|\\.\'
string                  \"([^"]|(\\\"))*\"
verboseString           @\"([^"]|(\"\"))*\"
newline                 (\n)|(\r\n)
%% Rules
[ ]+ /* ignore whitespace */;
{newline}                                            printf("Lex:NEWLINE '\\n' \n"); return NEWLINE;
\/\/.\n                                              printf("Lex:COMMENT '%s' \n",yytext); return COMMENT;
"(*"."*)"                                            printf("Lex:COMMENT '%s' \n",yytext); return COMMENT;
([ ]*)                                               printf("Lex:UNIT '%s' \n",yytext); return UNIT;
(true) | (false)                                     printf("Lex:BOOL '%s' \n",yytext); return BOOL;
{char}                                               printf("Lex:CHAR '%s' \n",yytext); return CHAR;
{char}B                                              printf("Lex:BYTE '%s' \n",yytext); return BYTE;
{string}|{verboseString}                             printf("Lex:STRING '%s' \n",yytext); return STRING; /* missing tripple quote-strings */
{string}B                                            printf("Lex:BYTELIST '%s' \n",yytext); return BYTELIST;
({D}+|0[bB]{B}+|0[oO]{O}+|0[xX]{H}+)({IS}?)          printf("Lex:INT '%s' \n",yytext); return INT;
({D}+\.{D}*)|({D}+(\.{D}*)?(e|E)(\+|\-)?({D}+)){FS}? printf("Lex:FLOAT '%s' \n",yytext); return FLOAT;
\-                                                   printf("Lex:INFIXOP '%s' \n",yytext); return INFIXOP;
\*|\+|\/|\-                                          printf("Lex:PREFIXOP '%s' \n",yytext); return PREFIXOP;
\(\*                                                 printf("Lex:BLOCK_COMMENT_START '%s' \n",yytext); return BLOCK_COMMENT_START;
\*\)                                                 printf("Lex:BLOCK_COMMENT_END '%s' \n",yytext); return BLOCK_COMMENT_END;
\/\/[^\n\r]*                                         printf("Lex:END_OF_LINE_COMMENT '%s' \n",yytext); return END_OF_LINE_COMMENT;
_                                                    printf("Lex:UNDERSCORE '%s' \n",yytext); return UNDERSCORE;
\.                                                   printf("Lex:DOT '%s' \n",yytext); return DOT;
\<\-                                                 printf("Lex:ASSIGNOP '%s' \n",yytext); return ASSIGNOP;
\(                                                   printf("Lex:LEFTPARN '%s' \n",yytext); return LEFTPARN;
\)                                                   printf("Lex:RIGHTPARN '%s' \n",yytext); return RIGHTPARN;
\.\[                                                 printf("Lex:LEFTINDEXING '%s' \n",yytext); return LEFTINDEXING;
\]                                                   printf("Lex:RIGHTINDEXING '%s' \n",yytext); return RIGHTINDEXING;
=                                                    printf("Lex:EQ '%s' \n",yytext); return EQ;
abstract                                             printf("Lex:ABSTRACT '%s' \n",yytext); return ABSTRACT;
and                                                  printf("Lex:AND '%s' \n",yytext); return AND;
as                                                   printf("Lex:AS '%s' \n",yytext); return AS;
assert                                               printf("Lex:ASSERT '%s' \n",yytext); return ASSERT;
base                                                 printf("Lex:BASE '%s' \n",yytext); return BASE;
begin                                                printf("Lex:_BEGIN '%s' \n",yytext); return _BEGIN;
class                                                printf("Lex:CLASS '%s' \n",yytext); return CLASS;
default                                              printf("Lex:DEFAULT '%s' \n",yytext); return DEFAULT;
delegate                                             printf("Lex:DELEGATE '%s' \n",yytext); return DELEGATE;
do                                                   printf("Lex:DO '%s' \n",yytext); return DO;
done                                                 printf("Lex:DONE '%s' \n",yytext); return DONE;
downcast                                             printf("Lex:DOWNCAST '%s' \n",yytext); return DOWNCAST;
downto                                               printf("Lex:DOWNTO '%s' \n",yytext); return DOWNTO;
elif                                                 printf("Lex:ELIF '%s' \n",yytext); return ELIF;
else                                                 printf("Lex:ELSE '%s' \n",yytext); return ELSE;
end                                                  printf("Lex:END '%s' \n",yytext); return END;
exception                                            printf("Lex:EXCEPTION '%s' \n",yytext); return EXCEPTION;
extern                                               printf("Lex:EXTERN '%s' \n",yytext); return EXTERN;
false                                                printf("Lex:FALSE '%s' \n",yytext); return FALSE;
finally                                              printf("Lex:FINALLY '%s' \n",yytext); return FINALLY;
for                                                  printf("Lex:FOR '%s' \n",yytext); return FOR;
fun                                                  printf("Lex:FUN '%s' \n",yytext); return FUN;
function                                             printf("Lex:FUNCTION '%s' \n",yytext); return FUNCTION;
global                                               printf("Lex:GLOBAL '%s' \n",yytext); return GLOBAL;
if                                                   printf("Lex:IF '%s' \n",yytext); return IF;
in                                                   printf("Lex:IN '%s' \n",yytext); return IN;
inherit                                              printf("Lex:INHERIT '%s' \n",yytext); return INHERIT;
inline                                               printf("Lex:INLINE '%s' \n",yytext); return INLINE;
interface                                            printf("Lex:INTERFACE '%s' \n",yytext); return INTERFACE;
internal                                             printf("Lex:INTERNAL '%s' \n",yytext); return INTERNAL;
lazy                                                 printf("Lex:LAZY '%s' \n",yytext); return LAZY;
let                                                  printf("Lex:LET '%s' \n",yytext); return LET;
match                                                printf("Lex:MATCH '%s' \n",yytext); return MATCH;
member                                               printf("Lex:MEMBER '%s' \n",yytext); return MEMBER;
module                                               printf("Lex:MODULE '%s' \n",yytext); return MODULE;
mutable                                              printf("Lex:MUTABLE '%s' \n",yytext); return MUTABLE;
namespace                                            printf("Lex:NAMESPACE '%s' \n",yytext); return NAMESPACE;
new                                                  printf("Lex:NEW '%s' \n",yytext); return NEW;
null                                                 printf("Lex:_NULL '%s' \n",yytext); return _NULL;
of                                                   printf("Lex:OF '%s' \n",yytext); return OF;
open                                                 printf("Lex:OPEN '%s' \n",yytext); return OPEN;
or                                                   printf("Lex:OR '%s' \n",yytext); return OR;
override                                             printf("Lex:OVERRIDE '%s' \n",yytext); return OVERRIDE;
private                                              printf("Lex:PRIVATE '%s' \n",yytext); return PRIVATE;
public                                               printf("Lex:PUBLIC '%s' \n",yytext); return PUBLIC;
rec                                                  printf("Lex:REC '%s' \n",yytext); return REC;
return                                               printf("Lex:RETURN '%s' \n",yytext); return RETURN;
sig                                                  printf("Lex:SIG '%s' \n",yytext); return SIG;
static                                               printf("Lex:STATIC '%s' \n",yytext); return STATIC;
struct                                               printf("Lex:STRUCT '%s' \n",yytext); return STRUCT;
then                                                 printf("Lex:THEN '%s' \n",yytext); return THEN;
to                                                   printf("Lex:TO '%s' \n",yytext); return TO;
true                                                 printf("Lex:TRUE '%s' \n",yytext); return TRUE;
try                                                  printf("Lex:TRY '%s' \n",yytext); return TRY;
type                                                 printf("Lex:TYPE '%s' \n",yytext); return TYPE;
upcast                                               printf("Lex:UPCAST '%s' \n",yytext); return UPCAST;
use                                                  printf("Lex:USE '%s' \n",yytext); return USE;
val                                                  printf("Lex:VAL '%s' \n",yytext); return VAL;
void                                                 printf("Lex:VOID '%s' \n",yytext); return VOID;
when                                                 printf("Lex:WHEN '%s' \n",yytext); return WHEN;
while                                                printf("Lex:WHILE '%s' \n",yytext); return WHILE;
with                                                 printf("Lex:WITH '%s' \n",yytext); return WITH;
yield                                                printf("Lex:YIELD '%s' \n",yytext); return YIELD;
{L}*                                                 printf("Lex:IDENT '%s' \n",yytext); return IDENT;
%% Subroutines
/*
(\n)|(\r\n)                                          printf("Lex:NEWLINE '\\n' \n"); return NEWLINE;
char \'[^\']|(\\(([bnrt\\\"\'afv])|(u([0-9a-fA-F]{4}))|(U([0-9a-fA-F]{8})|([0-9]{3}))))\'*/
/*.                                                                                                printf("Lex:codepoint \n"); return CODEPOINT; //return (int) yytext[0];*/
/*
\||->|<-|\.|\:|\(|\)|\[|\]|\[\||\|\]|\{|\}|:\?>|:\?|:>|\.\.|::|:=|;;|;|=                           return SYMBOLIC_KEYWORD;
\!|%|&|\*|\+|\-|\.|\/|<|=|>|@|\^|\||~                                                              return FIRST_OP_CHAR;
*/
