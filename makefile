FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	make -C src
	make -C tex always

all:
	make -C src
	make -C tex all

#fsharpNotes.pdf: $(TEX) $(FSCRIPT)
#	pdflatex fsharpNotes

clean:
	make -C tex clean
