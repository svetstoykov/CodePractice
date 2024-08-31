defmodule LengthOfLastWord do
  @spec length_of_last_word(s :: String.t()) :: integer
  def length_of_last_word(s) do
    [head | _] =
      String.split(s)
      |> Enum.reverse()

    String.length(head)
  end
end
