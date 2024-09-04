defmodule FindOutlier do
  def find_outlier(integers), do: find_outlier(integers, [], [])

  defp find_outlier([head | tail], even, odd) when rem(head, 2) == 0, do: find_outlier(tail, [head | even], odd)
  defp find_outlier([head | tail], even, odd), do: find_outlier(tail, even, [head | odd])
  defp find_outlier([], [even], _), do: even
  defp find_outlier([], _, [odd]), do: odd
end
