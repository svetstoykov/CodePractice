defmodule MultipleOfThreeOrFive do
  def solution(number) do
    solve(number)
  end

  defp solve(number) when number < 0, do: 0

  defp solve(number) do
    Enum.to_list(1..(number-1))
    |> Enum.filter(&(rem(&1, 3) == 0 || rem(&1, 5) == 0))
    |> Enum.sum()
  end
end
