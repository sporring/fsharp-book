FSCRIPT := $(wildcard *.fscript)
FSX := $(wildcard *.fsx)
OBJS := $(patsubst %.fscript,%.out,$(FSCRIPT)) $(patsubst %.fsx,%.out,$(FSX))

%.out: %.fscript
	./fscript2out $<

%.out: %.fsx
	./fsx2out $<

all: $(OBJS)
