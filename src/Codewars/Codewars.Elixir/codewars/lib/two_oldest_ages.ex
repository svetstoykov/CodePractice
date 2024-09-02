defmodule TwoOldestAges do
  def two_oldest_ages(ages) do
    Enum.sort(ages, fn (a,b) -> a >= b end)
    |> Enum.take(2)
    |> Enum.reverse()
  end
end
