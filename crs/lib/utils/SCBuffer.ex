defmodule Crs.Utils.SCBuffer do

    @on_load :load_nifs

    def load_nifs do
        :erlang.load_nif('./ffi', 0)
    end

    def new(), do: raise "SCBuffer.new/0 not implemented"
    def new(_size), do: raise "SCBuffer.new/1 not implemented"
    def from(_data), do: raise "SCBuffer.from/1 not implemented"

end