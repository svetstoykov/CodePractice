defmodule PlusOneTest do
  use ExUnit.Case

  test "Example 1: Incrementing [1, 2, 3]" do
    assert PlusOne.plus_one([1, 2, 3]) == [1, 2, 4]
  end

  test "Example 2: Incrementing [4, 3, 2, 1]" do
    assert PlusOne.plus_one([4, 3, 2, 1]) == [4, 3, 2, 2]
  end

  test "Example 3: Incrementing [9]" do
    assert PlusOne.plus_one([9]) == [1, 0]
  end

  test "Incrementing [0]" do
    assert PlusOne.plus_one([0]) == [1]
  end

  test "Incrementing [9, 9, 9]" do
    assert PlusOne.plus_one([9, 9, 9]) == [1, 0, 0, 0]
  end

  test "Incrementing [2, 9, 9]" do
    assert PlusOne.plus_one([2, 9, 9]) == [3, 0, 0]
  end

  test "Incrementing [1, 0, 0, 0, 0]" do
    assert PlusOne.plus_one([1, 0, 0, 0, 0]) == [1, 0, 0, 0, 1]
  end
end
