defmodule DuplicateCount do
  def count(str) do
    String.downcase(str)
    |> String.to_charlist()
    |> Enum.frequencies()
    |> Enum.count(fn {_, count} -> count > 1 end)
  end
end
