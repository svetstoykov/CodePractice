defmodule FindTheOddInt do
  def find(list) do
    find(list, %{})
    |> elem(0)
  end

  defp find([head | tail], map) do
    find(tail, Map.update(map, head, 1, &(&1 + 1)))
  end

  defp find([], map), do: Enum.find(map, fn {_, count} -> rem(count, 2) !== 0 end)
end
