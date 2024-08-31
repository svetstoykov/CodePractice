defmodule FirstOccurrence do
  @spec str_str(haystack :: String.t(), needle :: String.t()) :: integer
  def str_str(haystack, needle) do
    stack_len = String.length(haystack)
    needle_len = String.length(needle)

    cond do
      stack_len < needle_len ->
        -1

      String.slice(haystack, 0..(needle_len - 1)) == needle ->
        0

      true ->
        search(haystack, stack_len, needle, needle_len, 0)
    end
  end

  defp search(haystack, stack_len, needle, needle_len, current_index) do
    cond do
      current_index + needle_len > stack_len ->
        -1

      String.slice(haystack, current_index..(current_index + needle_len - 1)) == needle ->
        current_index

      true ->
        search(haystack, stack_len, needle, needle_len, current_index + 1)
    end
  end
end
