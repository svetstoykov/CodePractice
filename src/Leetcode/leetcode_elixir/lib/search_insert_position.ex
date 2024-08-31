defmodule SearchInsertPosition do
  @spec search_insert(nums :: [integer], target :: integer) :: integer
  def search_insert(nums, target) do
    binary_search(nums, target, 0, length(nums) - 1)
  end

  defp binary_search(nums, target, start, tail) when start <= tail do
    mid_point = div(start + tail, 2)
    mid_value = Enum.at(nums, mid_point)

    cond do
      mid_value == target ->
        mid_point
      mid_value < target ->
        binary_search(nums, target, mid_point + 1, tail)
      mid_value > target ->
        binary_search(nums, target, start, mid_point - 1)
    end
  end

  defp binary_search(_nums, _target, start, _tail), do: start
end
