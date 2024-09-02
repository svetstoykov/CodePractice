defmodule CodewarsTest do
  use ExUnit.Case

  test "Descending Order" do
      Enum.each [
          {0,0},
          {123456789,987654321},
          {567821,876521},
          {55672,76552},
          {1231293922,9933222211},
      ], fn {n,expected} ->
          actual = DescendingOrder.descending_order(n)
          assert actual == expected
      end
  end

  test "Get Middle" do
    assert GetMiddle.get_middle("test") == "es"
    assert GetMiddle.get_middle("testing") == "t"
  end

  test "Two Oldest Ages" do
    assert TwoOldestAges.two_oldest_ages([6,5,83,5,3,18]) == [18, 83]
    assert TwoOldestAges.two_oldest_ages([1,5,87,45,8,8]) == [45, 87]
  end

  test "Array Diff" do
    assert ArrayDiff.array_diff([1, 2], [1]) == [2]
    assert ArrayDiff.array_diff([1,2,2], [1]) == [2,2]
    assert ArrayDiff.array_diff([1,2,2], [2]) == [1]
    assert ArrayDiff.array_diff([1,2,2], []) == [1,2,2]
    assert ArrayDiff.array_diff([], [1,2]) == []
    assert ArrayDiff.array_diff([1,2,3], [1,2]) == [3]
  end

  test "Find The Odd Int" do
    assert FindTheOddInt.find([20,1,-1,2,-2,3,3,5,5,1,2,4,20,4,-1,-2,5]) == 5
    assert FindTheOddInt.find([1,1,2,-2,5,2,4,4,-1,-2,5]) == -1
    assert FindTheOddInt.find([20,1,1,2,2,3,3,5,5,4,20,4,5]) == 5
    assert FindTheOddInt.find([10]) == 10
    assert FindTheOddInt.find([1,1,1,1,1,1,10,1,1,1,1]) == 10
    assert FindTheOddInt.find([5,4,3,2,1,5,4,3,2,10,10]) == 1
  end
end
