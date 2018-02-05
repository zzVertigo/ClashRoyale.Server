CC        := gcc
SRC_DIR   := ffi
BUILD_DIR := build
INCLUDES  := -I/usr/lib/erlang/erts-9.2/include
LDFLAGS   := 
CFLAGS    := -g -Wall -O3 -c -fPIC
EXT       := c
NAME      := ffi

SOURCES := $(shell find $(SRC_DIR) -name '*.$(EXT)' | sort -k 1nr | cut -f2-)
OBJECTS := $(SOURCES:$(SRC_DIR)/%.$(EXT)=$(BUILD_DIR)/%.o)
DEPS    := $(OBJECTS:.o=.d)

$(NAME) : $(OBJECTS)
	$(CC) $(OBJECTS) -shared -o $@.so $(LDFLAGS)

$(BUILD_DIR)/%.o : $(SRC_DIR)/%.$(EXT)
	$(CC) $(CFLAGS) $(INCLUDES) -MMD -MP -c $< -o $@

clean:
	rm -rf $(BUILD_DIR) && mkdir $(BUILD_DIR)

run : $(NAME)
	mix escript.build && ./crs

-include $(DEPS)