defmodule DigitalRoot do
  def digital_root(n) when n < 10, do: n
  def digital_root(n), do: Integer.digits(n) |> Enum.sum() |> digital_root
end
