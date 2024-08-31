defmodule PlusOne do
  @spec plus_one(digits :: [integer]) :: [integer]
  def plus_one(digits) do
    digits
    #[2, 9, 9]
    |> Enum.reverse()
    #[9,9,2]
    |> do_plus_one()
    |> Enum.reverse()
  end

  defp do_plus_one([9 | tail]) do
    [0 | do_plus_one(tail)]
  end

  defp do_plus_one([]) do
    [1]
  end

  defp do_plus_one([head | tail]) do
    [head + 1 | tail]
  end
end
