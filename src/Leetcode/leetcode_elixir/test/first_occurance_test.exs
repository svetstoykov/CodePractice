defmodule FirstOccurrenceTests do
  use ExUnit.Case
  doctest FirstOccurrence

  test "first" do
    assert FirstOccurrence.str_str("hello", "h") === 0
  end

  test "second" do
    assert FirstOccurrence.str_str("thisisthehaystack", "hay") === 9
  end

  test "third" do
    assert FirstOccurrence.str_str("thisismyhay", "car") === -1
  end
end
