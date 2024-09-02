defmodule GetMiddle do
  def get_middle(str) do
    length = String.length(str)
    mid = div(length, 2)

    case rem(length, 2) === 0 do
      true -> String.slice(str, (mid - 1)..mid)
      _ -> String.slice(str, mid..mid)
    end
  end
end
