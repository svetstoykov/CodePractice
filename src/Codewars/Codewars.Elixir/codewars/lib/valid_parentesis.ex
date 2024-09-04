defmodule ValidParentesis do
  @opening %{?( => ?), ?{ => ?}, ?[ => ?]}

  def solve(braces) do
    is_valid(String.to_charlist(braces), [])
  end

  defp is_valid([head | tail], stack) do
    cond do
      Map.has_key?(@opening, head) -> is_valid(tail, [head | stack])
      length(stack) > 0 and Map.get(@opening, hd(stack)) == head -> is_valid(tail, tl(stack))
      true -> false
    end
  end

  defp is_valid([], []), do: true
  defp is_valid([], [_head | _tail]), do: false
end
