/* A Bison parser, made by GNU Bison 3.0.4.  */

/* Bison interface for Yacc-like parsers in C

   Copyright (C) 1984, 1989-1990, 2000-2015 Free Software Foundation, Inc.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.

   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

#ifndef YY_YY_FFLAT_TAB_H_INCLUDED
# define YY_YY_FFLAT_TAB_H_INCLUDED
/* Debug traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif
#if YYDEBUG
extern int yydebug;
#endif

/* Token type.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
  enum yytokentype
  {
    _EOF = 258,
    COMMENT = 259,
    UNIT = 260,
    BOOL = 261,
    CHAR = 262,
    BYTE = 263,
    STRING = 264,
    BYTELIST = 265,
    INT = 266,
    FLOAT = 267,
    CODEPOINT = 268,
    NEWLINE = 269,
    INFIXOP = 270,
    PREFIXOP = 271,
    BLOCK_COMMENT_START = 272,
    BLOCK_COMMENT_END = 273,
    END_OF_LINE_COMMENT = 274,
    KEYWORD = 275,
    SYMBOLIC_KEYWORD = 276,
    IDENT = 277,
    FIRST_OP_CHAR = 278,
    DOT = 279,
    ASSIGNOP = 280,
    LEFTPARN = 281,
    RIGHTPARN = 282,
    LEFTINDEXING = 283,
    RIGHTINDEXING = 284,
    EQ = 285,
    UNDERSCORE = 286,
    ABSTRACT = 287,
    AND = 288,
    AS = 289,
    ASSERT = 290,
    BASE = 291,
    _BEGIN = 292,
    CLASS = 293,
    DEFAULT = 294,
    DELEGATE = 295,
    DO = 296,
    DONE = 297,
    DOWNCAST = 298,
    DOWNTO = 299,
    ELIF = 300,
    ELSE = 301,
    END = 302,
    EXCEPTION = 303,
    EXTERN = 304,
    FALSE = 305,
    FINALLY = 306,
    FOR = 307,
    FUN = 308,
    FUNCTION = 309,
    GLOBAL = 310,
    IF = 311,
    IN = 312,
    INHERIT = 313,
    INLINE = 314,
    INTERFACE = 315,
    INTERNAL = 316,
    LAZY = 317,
    LET = 318,
    MATCH = 319,
    MEMBER = 320,
    MODULE = 321,
    MUTABLE = 322,
    NAMESPACE = 323,
    NEW = 324,
    _NULL = 325,
    OF = 326,
    OPEN = 327,
    OR = 328,
    OVERRIDE = 329,
    PRIVATE = 330,
    PUBLIC = 331,
    REC = 332,
    RETURN = 333,
    SIG = 334,
    STATIC = 335,
    STRUCT = 336,
    THEN = 337,
    TO = 338,
    TRUE = 339,
    TRY = 340,
    TYPE = 341,
    UPCAST = 342,
    USE = 343,
    VAL = 344,
    VOID = 345,
    WHEN = 346,
    WHILE = 347,
    WITH = 348,
    YIELD = 349
  };
#endif
/* Tokens.  */
#define _EOF 258
#define COMMENT 259
#define UNIT 260
#define BOOL 261
#define CHAR 262
#define BYTE 263
#define STRING 264
#define BYTELIST 265
#define INT 266
#define FLOAT 267
#define CODEPOINT 268
#define NEWLINE 269
#define INFIXOP 270
#define PREFIXOP 271
#define BLOCK_COMMENT_START 272
#define BLOCK_COMMENT_END 273
#define END_OF_LINE_COMMENT 274
#define KEYWORD 275
#define SYMBOLIC_KEYWORD 276
#define IDENT 277
#define FIRST_OP_CHAR 278
#define DOT 279
#define ASSIGNOP 280
#define LEFTPARN 281
#define RIGHTPARN 282
#define LEFTINDEXING 283
#define RIGHTINDEXING 284
#define EQ 285
#define UNDERSCORE 286
#define ABSTRACT 287
#define AND 288
#define AS 289
#define ASSERT 290
#define BASE 291
#define _BEGIN 292
#define CLASS 293
#define DEFAULT 294
#define DELEGATE 295
#define DO 296
#define DONE 297
#define DOWNCAST 298
#define DOWNTO 299
#define ELIF 300
#define ELSE 301
#define END 302
#define EXCEPTION 303
#define EXTERN 304
#define FALSE 305
#define FINALLY 306
#define FOR 307
#define FUN 308
#define FUNCTION 309
#define GLOBAL 310
#define IF 311
#define IN 312
#define INHERIT 313
#define INLINE 314
#define INTERFACE 315
#define INTERNAL 316
#define LAZY 317
#define LET 318
#define MATCH 319
#define MEMBER 320
#define MODULE 321
#define MUTABLE 322
#define NAMESPACE 323
#define NEW 324
#define _NULL 325
#define OF 326
#define OPEN 327
#define OR 328
#define OVERRIDE 329
#define PRIVATE 330
#define PUBLIC 331
#define REC 332
#define RETURN 333
#define SIG 334
#define STATIC 335
#define STRUCT 336
#define THEN 337
#define TO 338
#define TRUE 339
#define TRY 340
#define TYPE 341
#define UPCAST 342
#define USE 343
#define VAL 344
#define VOID 345
#define WHEN 346
#define WHILE 347
#define WITH 348
#define YIELD 349

/* Value type.  */
#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef int YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define YYSTYPE_IS_DECLARED 1
#endif


extern YYSTYPE yylval;

int yyparse (void);

#endif /* !YY_YY_FFLAT_TAB_H_INCLUDED  */
