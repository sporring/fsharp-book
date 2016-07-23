FSCRIPT := $(wildcard *.fscript)
FSX := $(wildcard *.fsx)
OSCRIPT := $(patsubst %.fscript,%.out,$(FSCRIPT))
OSX := $(patsubst %.fsx,%.out,$(FSX))

%.out: %.fscript
	./fscript2out $<

%.out: %.fsx
	./fsx2out $<

all: $(OSX) $(OSCRIPT)

cleanfscript:
	rm $(OSCRIPT)

cleanfsx:
	rm $(OSX)

