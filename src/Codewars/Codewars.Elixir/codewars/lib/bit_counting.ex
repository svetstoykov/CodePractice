defmodule BitCounting do
  def bits(n) do
    Integer.to_string(n, 2)
    |> String.to_charlist()
    |> Enum.count(&(&1 == ?1))
  end
end
