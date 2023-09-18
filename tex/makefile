FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	latexmk -pdf fsharpNotes
	../scripts/split fsharpNotes.pdf chapter

#fsharpNotes.pdf: $(TEX) $(FSCRIPT)
#	pdflatex fsharpNotes

clean:
	latexmk -c
