FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	make -C src
#	latexmk -pdf fsharpNotes
	latexmk -pdf springer

#fsharpNotes.pdf: $(TEX) $(FSCRIPT)
#	pdflatex fsharpNotes

springer.pdf: $(TEX) $(FSCRIPT)
	pdflatex springer

