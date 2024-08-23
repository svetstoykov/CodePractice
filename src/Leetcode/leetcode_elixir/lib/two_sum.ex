defmodule TwoSum do
  @spec two_sum(nums :: [integer], target :: integer) :: [integer]
  def two_sum(nums, target) do
    do_find_indices(nums, target, 0, %{})
  end

  defp do_find_indices([], _target, _index, _map), do: []

  defp do_find_indices([num | rest], target, index, map) do
    complement = target - num

    case Map.get(map, complement) do
      nil
        -> do_find_indices(rest, target, index + 1, Map.put(map, num, index))
      complement_index
        -> [complement_index, index]
    end
  end
end
