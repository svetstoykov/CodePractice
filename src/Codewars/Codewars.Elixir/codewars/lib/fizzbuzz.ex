defmodule Fizzbuzz do
  def fizzbuzz(n) do
    Range.new(1, n)
    |> Enum.to_list()
    |> Enum.map(&process/1)
  end

  defp process(n) do
    cond do
      rem(n, 3) == 0 && rem(n, 5) == 0 -> "FizzBuzz"
      rem(n, 5) == 0 -> "Buzz"
      rem(n, 3) == 0 -> "Fizz"
      true -> n
    end
  end
end
