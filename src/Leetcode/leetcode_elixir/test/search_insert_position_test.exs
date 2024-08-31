defmodule SearchInsertPositionTests do
  use ExUnit.Case
  doctest SearchInsertPosition

  test "first" do
    assert SearchInsertPosition.search_insert([1, 3, 5, 6], 5) === 2
  end

  test "second" do
    assert SearchInsertPosition.search_insert([1, 3, 5, 6], 2) === 1
  end

  test "third" do
    assert SearchInsertPosition.search_insert([1, 3, 5, 6], 7) === 4
  end

  test "forth" do
    assert SearchInsertPosition.search_insert([1, 3, 5, 6], 0) === 0
  end
end
