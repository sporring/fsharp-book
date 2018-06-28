FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	make -C src
	latexmk -pdf fsharpNotes

fsharpNotes.pdf: $(TEX) $(FSCRIPT)
	pdflatex fsharpNotes

