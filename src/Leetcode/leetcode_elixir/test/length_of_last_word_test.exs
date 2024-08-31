defmodule LengthOfLastWordTests do
  use ExUnit.Case
  doctest LengthOfLastWord

  test "first" do
    assert LengthOfLastWord.length_of_last_word("Hello World") === 5
  end

  test "second" do
    assert LengthOfLastWord.length_of_last_word("   fly me   to   the moon  ") === 4
  end

  test "third" do
    assert LengthOfLastWord.length_of_last_word("luffy is still joyboy") === 6
  end
end
