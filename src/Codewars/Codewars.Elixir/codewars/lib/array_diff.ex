defmodule ArrayDiff do
  def array_diff(a, b) do
    get_diff(a, b)
  end

  defp get_diff([], _), do: []
  defp get_diff(a, []), do: a

  defp get_diff(a, b) do
    Enum.filter(a, fn x -> !Enum.any?(b, fn y -> x == y end) end)
  end
end
