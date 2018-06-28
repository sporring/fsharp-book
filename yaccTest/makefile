LEX := $(wildcard *.l)
YACC := $(wildcard *.y)
BASE = $(patsubst %.l,%,$(LEX))

fflat: fflat.y fflat.l
	lex -o $@.yy.c $@.l
	yacc -o $@.tab.c -d $@.y
	cc $@.yy.c $@.tab.c -std=gnu89 -o $@
