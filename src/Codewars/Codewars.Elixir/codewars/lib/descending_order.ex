defmodule DescendingOrder do
  def descending_order(n) when is_integer(n) do
    n
    |> Integer.digits()
    |> Enum.sort(&(&1 >= &2))
    |> Integer.undigits()
  end
end
