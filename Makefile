# Following example from Stack Overflow https://stackoverflow.com/questions/20393853/how-do-write-a-makefile-for-c
MAIN_FILE = tictactoe

CSHARP_SOURCE_FILES = $(wildcard *.cs)

CSHARP_FLAGS = -out:$(EXECUTABLE)

CSHARP_FLAGS += /doc:tictactoe.xml

CSHARP_COMPILER = mcs

# Defaults to the name of the MAIN_FILE
EXECUTABLE = $(MAIN_FILE).exe

RM_CMD = -rm -f $(EXECUTABLE)

all: $(EXECUTABLE)

$(EXECUTABLE): $(CSHARP_SOURCE_FILES)
	@ echo $(CSHARP_COMPILER) $(CSHARP_SOURCE_FILES) $(CSHARP_FLAGS)
	@ $(CSHARP_COMPILER) $(CSHARP_SOURCE_FILES) $(CSHARP_FLAGS)
	@ echo compiling...

run: all
	./$(EXECUTABLE)

clean:
	@ $(RM_CMD)

remake:
	@ $(MAKE) clean
	@ $(MAKE)