defmodule Crs.Utils.SCBuffer do

    @on_load :load_nifs

    def load_nifs do
        :erlang.load_nif('./ffi', 0)
    end

    def new(), do: raise "SCBuffer.new/0 not implemented"
    def new(_size), do: raise "SCBuffer.new/1 not implemented"
    def from(_data), do: raise "SCBuffer.from/1 not implemented"

    def read(_buffer), do: raise "SCBuffer.read/1 not implemented"
    def readstr(_buffer), do: raise "SCBuffer.readstr/1 not implemented"
    def read16(_buffer), do: raise "SCBuffer.read16/1 not implemented"
    def read24(_buffer), do: raise "SCBuffer.read24/1 not implemented"
    def read32(_buffer), do: raise "SCBuffer.read32/1 not implemented"
    def read64(_buffer), do: raise "SCBuffer.read64/1 not implemented"
    def readu16(_buffer), do: raise "SCBuffer.readu16/1 not implemented"
    def readu24(_buffer), do: raise "SCBuffer.readu24/1 not implemented"
    def readu32(_buffer), do: raise "SCBuffer.readu32/1 not implemented"
    def readu64(_buffer), do: raise "SCBuffer.readu64/1 not implemented"

end