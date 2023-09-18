FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	make -C src
	make -C tex always
	cp tex/fsharpNotes.pdf .

all:
	make -C src
	make -C tex all
	cp tex/*.pdf .

#fsharpNotes.pdf: $(TEX) $(FSCRIPT)
#	pdflatex fsharpNotes

clean:
	latexmk -c
