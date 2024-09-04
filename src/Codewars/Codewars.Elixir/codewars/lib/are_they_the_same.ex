defmodule Aretheythesame do
  @spec comp([number], [number]) :: boolean
  def comp(a, b) do
    are_same(a, b)
  end

  defp are_same(a, b) when length(a) !== length(b), do: false

  defp are_same(a, b) do
    are_same_sorted(Enum.sort(a, &(&1 >= &2)), Enum.sort(b, &(&1 >= &2)))
  end

  defp are_same_sorted([head_a | tail_a], [head_b | tail_b]) do
    case head_a == square(head_b) do
      true -> are_same_sorted(tail_a, tail_b)
      false -> false
    end
  end

  defp are_same_sorted([], []), do: true

  defp square(a) do
    root = :math.sqrt(a)

    if trunc(root) == root do
      root
    else
      nil
    end
  end
end
