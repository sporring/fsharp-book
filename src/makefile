.SUFFIXES: # turn off implicit rules for easier debugging

FS := $(wildcard *.fs)
FSCRIPT := $(wildcard *.fsscript)
FSX := $(wildcard *.fsx)
FSX := $(filter-out filenamedialogue.fsx, $(FSX))
FSX := $(filter-out nestedRecModules.fsx, $(FSX))
FSX := $(filter-out userDialogue.fsx, $(FSX))
FSX := $(filter-out userDialoguePrintf.fsx, $(FSX))
FSX := $(filter-out quickStartSumInput.fsx, $(FSX))
FSX := $(filter-out quickStartDivisionInput.fsx, $(FSX))
FSX := $(filter-out quickStartRecursiveInput.fsx, $(FSX))
FSX := $(filter-out quickStartRecursiveInputComments.fsx, $(FSX))
FSX := $(filter-out quickStartWhileInput.fsx, $(FSX))
FSX := $(filter-out nestedModules.fsx, $(FSX))
FSX := $(filter-out nestedModulesApp.fsx, $(FSX))
FSX := $(filter-out Meta.fsx, $(FSX))
FSX := $(filter-out MetaExplicit.fsx, $(FSX))
#FSX := $(filter-out MetaHashApp.fsx, $(FSX))
FSX := $(filter-out namespace.fsx, $(FSX))
FSX := $(filter-out namespaceApp.fsx, $(FSX))
FSX := $(filter-out namespaceExtension.fsx, $(FSX))
FSX := $(filter-out classMemberDefinition.fsx, $(FSX))
FSX := $(filter-out classStaticMemberDefinition.fsx, $(FSX))
FSX := $(filter-out classStaticMemberDefinition.fsx, $(FSX))
FSX := $(filter-out baseUpcastApp.fsx, $(FSX))
FSX := $(filter-out baseUpcastBoardApp.fsx, $(FSX))
FSX := $(filter-out commandLineArgs.fsx, $(FSX))
FSX := $(filter-out commandLineArgsFail.fsx, $(FSX))
FSX := $(filter-out commandLineArgsSuccess.fsx, $(FSX))
FSX := $(filter-out readKey.fsx, $(FSX))
OS := $(patsubst %.fs,%.out,$(FSCRIPT))
OSCRIPT := $(patsubst %.fsscript,%.out,$(FSCRIPT))
OSX := $(patsubst %.fsx,%.out,$(FSX)) MetaExplicitApp.out MetaAppWOpen.out namespaceApp.out namespaceExtensionApp.out MetaExplicit.dll MetaExplicitDLLApp.out MetaExplicit.out MetaWAdd.fsi MetaWAddSig.out MetaWAdd.dll MetaWAdd.out MetaWAddRemoved.out baseUpcastApp.out baseUpcastBoardApp.out commandLineArgs.out commandLineArgsSuccess.out commandLineArgsFail.out MetaWOAddApp.out postfixTest.out postfixApp.out postfixTestGeneric.out postfixAppGeneric.out queueApp.out bTreeGenericApp.out bTreeSort.out

all: $(OS) $(OSX) $(OSCRIPT)

# Default implicit rules.
%.out: %.fsscript
	./fsscript2out $<

%.out: %.fsx
	./fsxeval2out $@ "" "dotnet fsi $^";

%.out: %.fs
	fsharpc --nologo -a $^

#	str="fsharpc --nologo $^ && mono $*.exe"; \
#	if [ $${#str} -le 70 ];\
#		then ./fsxeval2out $@ "" "$$str";\
#		else ./fsxeval2out $@ "" "fsharpc --nologo $^" "mono $*.exe";\
#	fi
#	str="dotnet fsi $^"; \
#	./fsx2out $<

# Regular compile into exe of last filename. Since .out is not a standard ending, $* does not work
MetaExplicitModuleDefinition.out: MetaExplicitModuleDefinition.fs MetaExplicitModuleDefinition.fsx
	./fsxeval2out $@ "" "fsharpc --nologo $^ && mono MetaApp.exe"
MetaApp.out: Meta.fsx MetaApp.fsx
	./fsxeval2out $@ "" "fsharpc --nologo $^ && mono MetaApp.exe"
MetaAppWOpen.out: MetaExplicit.fsx MetaAppWOpen.fsx
	./fsxeval2out $@ "" "fsharpc --nologo $^ && mono MetaAppWOpen.exe"
namespaceApp.out: namespace.fsx namespaceApp.fsx 
	./fsxeval2out $@ "" "fsharpc --nologo $^ && mono namespaceApp.exe"
vecCartesian2DApp.out: vecCartesian2D.fs vecCartesian2DApp.fsx
	./fsxeval2out $@ "" "fsharpc --nologo $^ && mono vecCartesian2DApp.exe"
vectorApp.out: vector.fs vectorApp.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
chessApp.out: chess.fs pieces.fs chessApp.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"

# Compile but with a temporary and hidden target
baseUpcastApp.out: baseUpcast.fs baseUpcastExtension.fs baseUpcastApp.fsx
	./fsxvar2out $@ "$$ fsharpc --nologo $^ && mono baseUpcastApp.exe" $^
baseUpcastBoardApp.out: baseUpcastBoard.fs baseUpcastExtensionLookup.fs baseUpcastBoardApp.fsx
	./fsxvar2out $@ "$$ fsharpc --nologo $^ && mono baseUpcastBoardApp.exe" $^
MetaExplicitApp.out: MetaExplicit.fsx MetaApp.fsx
	./fsxvar2out $@ "$$ fsharpc --nologo $^ && mono MetaApp.exe" $^
namespaceExtensionApp.out: namespace.fsx namespaceExtension.fsx namespaceApp.fsx
	./fsxvar2out $@ "$$ fsharpc --nologo $^ && mono namespaceApp.exe" $^

# Irregular compile
bTreeFromPostfix.out: postfixLibraryGeneric.fs bTreeFromPostfix.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
bTreeSort.out: bTreeGeneric.fsi bTreeGeneric.fs bTreeSort.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
queueApp.out: queue.fs queueApp.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
postfixTestGeneric.out: postfixLibraryGeneric.fsi postfixLibraryGeneric.fs postfixTestGeneric.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
postfixAppGeneric.out: postfixLibraryGeneric.fsi postfixLibraryGeneric.fs postfixAppGeneric.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
postfixTest.out: postfixLibrary.fsi postfixLibrary.fs postfixTest.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
postfixApp.out: postfixLibrary.fsi postfixLibrary.fs postfixApp.fsx
	./fsxeval2out $@ "" "dotnet fsi $^"
letValueScopeNestedScope.out: letValueScopeNestedScope.fsx
	./fsxeval2out letValueScopeNestedScope.out "" "fsharpc --nologo -a $^"
letValueScopeLowerError.out: letValueScopeLowerError.fsx
	./fsxeval2out letValueScopeLowerError.out "" "fsharpc --nologo -a $^"
quickStartRebindError.out: quickStartRebindError.fsx
	./fsxeval2out quickStartRebindError.out "" "fsharpc --nologo -a $^"
MetaExplicit.out MetaExplicit.dll: MetaExplicit.fsx
	./fsxeval2out MetaExplicit.out "" "fsharpc --nologo -a $^"
MetaExplicitDLLApp.out: MetaExplicit.dll MetaApp.fsx
	./fsxeval2out $@ "" "fsharpc --nologo -r $^ && mono MetaApp.exe"
#MetaHashApp.out: MetaExplicit.dll MetaHashApp.fsx
MetaHashApp.out: MetaExplicit.dll MetaHashApp.fsx
	./fsxeval2out $@ "" "fsharpc --nologo MetaHashApp.fsx && mono MetaHashApp.exe"
MetaWAddSig.out MetaWAdd.fsi: MetaWAdd.fs
	./fsxeval2out MetaWAddSig.out "" "fsharpc --nologo --sig:MetaWAdd.fsi -a $^"
MetaWAdd.dll MetaWAdd.out: MetaWAdd.fsi MetaWAdd.fs
	./fsxeval2out MetaWAdd.out "" "fsharpc --nologo -a $^"
MetaWAddRemoved.out: MetaWAdd.dll MetaWAddRemoved.fsi MetaWOAddApp.fsx
	./fsxeval2out $@ "" "fsharpc --nologo -r $^"
commandLineArgs.out: commandLineArgs/Program.fs
	./fsxeval2out $@ "" "cd $(basename $@); dotnet run Hello World"
commandLineArgsSuccess.out: commandLineArgs/Program.fs
	./fsxeval2out $@ "" 'cd commandLineArgs; if dotnet run Hello World; then echo "success"; else echo "failure"; fi'
commandLineArgsFail.out: commandLineArgsFail/Program.fs
	./fsxeval2out $@ "" 'cd $(basename $@); if dotnet run; then echo "success"; else echo "failure"; fi'
cleanfscript:
	rm $(OSCRIPT)

cleanfsx:
	rm $(OSX)

# Do something about userDialoguePrintf !
# Do something about userDialogue !
# Do something about readKey !
