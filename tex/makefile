FSCRIPT := $(wildcard src/*.fsscript) $(wildcard src/*.fsx) $(wildcard src/*.fs) $(wildcard src/*.fsi)
TEX := $(wildcard *.tex)

always:
	latexmk -pdf fsharpNotes

all:
	latexmk -pdf fsharpNotes
	latexmk -pdf introduction
	latexmk -pdf quickStartGuide
	latexmk -pdf numbersCharsNStrings
	latexmk -pdf valuesFunctionsNStatements
	latexmk -pdf types
	latexmk -pdf makingPrograms
	latexmk -pdf declarative
	latexmk -pdf lists
	latexmk -pdf recursion
	latexmk -pdf nameSpacesNModules
	latexmk -pdf higherOrderFunctions
	latexmk -pdf collections
	latexmk -pdf imperative
	latexmk -pdf IO
	latexmk -pdf mutableValues
	latexmk -pdf testing
	latexmk -pdf classes
	latexmk -pdf inheritance
	latexmk -pdf objectOrientedDesign
	latexmk -pdf console
	latexmk -pdf numberSystems
	latexmk -pdf characterSets
	latexmk -pdf commonLanguageInfrastructure

#fsharpNotes.pdf: $(TEX) $(FSCRIPT)
#	pdflatex fsharpNotes

clean:
	latexmk -c
