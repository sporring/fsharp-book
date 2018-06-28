/* See http://www.lysator.liu.se/c/ANSI-C-grammar-y.html and http://dinosaur.compilertools.net/yacc/index.html */
%{
#include <stdio.h>
#include <string.h>

void yyerror(const char *str)
{
        fprintf(stderr,"error: %s\n",str);
}
 
int yywrap()
{
        return 1;
} 
  
int main()
{
        yyparse();
} 

%}

%token _EOF COMMENT UNIT BOOL CHAR BYTE STRING BYTELIST INT FLOAT CODEPOINT NEWLINE INFIXOP PREFIXOP  BLOCK_COMMENT_START BLOCK_COMMENT_END END_OF_LINE_COMMENT KEYWORD SYMBOLIC_KEYWORD IDENT FIRST_OP_CHAR DOT ASSIGNOP LEFTPARN RIGHTPARN LEFTINDEXING RIGHTINDEXING EQ UNDERSCORE ABSTRACT AND AS ASSERT BASE _BEGIN CLASS DEFAULT DELEGATE DO DONE DOWNCAST DOWNTO ELIF ELSE END EXCEPTION EXTERN FALSE FINALLY FOR FUN FUNCTION GLOBAL IF IN INHERIT INLINE INTERFACE INTERNAL LAZY LET MATCH MEMBER MODULE MUTABLE NAMESPACE NEW _NULL OF OPEN OR OVERRIDE PRIVATE PUBLIC REC RETURN SIG STATIC STRUCT THEN TO TRUE TRY TYPE UPCAST USE VAL VOID WHEN WHILE WITH YIELD

%define parse.error verbose
%start script_file
%%

/*script_fragment:
		module_elems
	;
*/
script_file:
		implementation_file
	;
implementation_file:
/* 		namespace_decl_groups */
/* 	| 	named_module */
 	 	anonymous_module {printf("implementation_file: anonymous_module\n");}
 	;
/* namespace_decl_groups: */
/* 		/\* empty*\/ */
/* 	| 	namespace_decl_groups namespace_decl_group */
/* 	; */
/* namespace_decl_group: */
/* 		"namespace" long_ident module_elems */
/* 	; */
/* named_module: */
/* 		"module" long_ident module_elems */
/* 	; */
anonymous_module:
		module_elems {printf("anonymous_elems: module_elems\n");}
	;

module_elems:
		module_elem {printf("module_elems: module_elem\n");}
	|	module_elem NEWLINE module_elems {printf("module_elems: module_elem module_elems\n");}
	;
module_elem: /* empty */ {printf("module_elem: /* empty */\n");}
	|	module_function_or_value_defn  {printf("module_elem: module_function_or_value_defn\n");}
/*	|	type_defns
	|	exception_defn
	|	module_defn
	|	module_abbrev
	|	import_decl
	|	compiler_directive_decl*/
	;
module_function_or_value_defn:
/*				"let" function_defn*/
		LET value_defn {printf("module_function_or_value_defn: LET value_defn\n");}
	|	DO expr {printf("module_function_or_value_defn: DO expr\n");}
	;
/* function_defn: */
/* 		ident_or_op argument_pats "=" expr */
/* 	; */

/* argument_pats: */
/* 		atomic_pat */
/* 	|	argument_pats atomic_pat */
/* 	; */
/* atomic_pat: */
/* 		pat */
/* 	; */
value_defn:
		mutableopt pat EQ expr {printf("value_defn: mutableopt pat \"=\" expr\n");}
	;
pat:
		const  {printf("pat: const\n");}
	|	long_ident {printf("pat: long_ident\n");}
	|	UNDERSCORE {printf("pat: UNDERSCORE\n");}
	;
mutableopt:	/* empty */ {printf("mutableopt: /* empty */\n");}
	|	MUTABLE {printf("mutableopt: mutable\n");}
	;
expr:		const {printf("expr: const\n");}
	|	LEFTPARN expr RIGHTPARN {printf("expr: paranthesized\n");}
	|	long_ident {printf("expr: long-ident\n");}
	|	expr expr {printf("expr: expr expr\n");}
	|	expr INFIXOP expr {printf("expr: expr INFIXOP expr\n");}
	|	PREFIXOP expr {printf("expr: PREFIXOP expr\n");}
	|	expr LEFTINDEXING expr RIGHTINDEXING {printf("expr: expr LEFTINDEXING expr RIGHTINDEXING\n");}
	|	expr ASSIGNOP expr {printf("expr: expr ASSIGNOP expr\n");}
	;
long_ident:
		IDENT {printf("long_ident: IDENT\n");}
	|	IDENT DOT long_ident {printf("long_ident: IDENT '.' long_ident\n");}
	;
const:
		UNIT {printf("const: UNIT\n");}
	|	BOOL {printf("const: BOOL\n");}
	| 	CHAR {printf("const: CHAR\n");}
	| 	BYTE {printf("const: BYTE\n");}
	| 	STRING {printf("const: STRING\n");}
	| 	BYTELIST {printf("const: BYTELIST\n");}
	| 	INT {printf("const: INT\n");}
	| 	FLOAT {printf("const: FLOAT\n");}
	;
