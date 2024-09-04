defmodule CodewarsTest do
  use ExUnit.Case

  test "Descending Order" do
    Enum.each(
      [
        {0, 0},
        {123_456_789, 987_654_321},
        {567_821, 876_521},
        {55672, 76552},
        {1_231_293_922, 9_933_222_211}
      ],
      fn {n, expected} ->
        actual = DescendingOrder.descending_order(n)
        assert actual == expected
      end
    )
  end

  test "Get Middle" do
    assert GetMiddle.get_middle("test") == "es"
    assert GetMiddle.get_middle("testing") == "t"
  end

  test "Two Oldest Ages" do
    assert TwoOldestAges.two_oldest_ages([6, 5, 83, 5, 3, 18]) == [18, 83]
    assert TwoOldestAges.two_oldest_ages([1, 5, 87, 45, 8, 8]) == [45, 87]
  end

  test "Array Diff" do
    assert ArrayDiff.array_diff([1, 2], [1]) == [2]
    assert ArrayDiff.array_diff([1, 2, 2], [1]) == [2, 2]
    assert ArrayDiff.array_diff([1, 2, 2], [2]) == [1]
    assert ArrayDiff.array_diff([1, 2, 2], []) == [1, 2, 2]
    assert ArrayDiff.array_diff([], [1, 2]) == []
    assert ArrayDiff.array_diff([1, 2, 3], [1, 2]) == [3]
  end

  test "Find The Odd Int" do
    assert FindTheOddInt.find([20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5]) == 5
    assert FindTheOddInt.find([1, 1, 2, -2, 5, 2, 4, 4, -1, -2, 5]) == -1
    assert FindTheOddInt.find([20, 1, 1, 2, 2, 3, 3, 5, 5, 4, 20, 4, 5]) == 5
    assert FindTheOddInt.find([10]) == 10
    assert FindTheOddInt.find([1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1]) == 10
    assert FindTheOddInt.find([5, 4, 3, 2, 1, 5, 4, 3, 2, 10, 10]) == 1
  end

  test "Find Outlier" do
    assert FindOutlier.find_outlier([0, 1, 2]) == 1
    assert FindOutlier.find_outlier([1, 2, 3]) == 2
    assert FindOutlier.find_outlier([2, 6, 8, 10, 3]) == 3
    assert FindOutlier.find_outlier([0, 0, 3, 0, 0]) == 3
    assert FindOutlier.find_outlier([1, 1, 0, 1, 1]) == 0
  end

  test "Duplicate count" do
    assert DuplicateCount.count("") == 0
    assert DuplicateCount.count("abcde") == 0
    assert DuplicateCount.count("aabbcde") == 2
    assert DuplicateCount.count("aabBcde") == 2
    assert DuplicateCount.count("Indivisibility") == 1
    assert DuplicateCount.count("Indivisibilities") == 2
  end

  test "Are they the Same" do
    IO.puts("Test 1")
    a = [121, 144, 19, 161, 19, 144, 19, 11]
    b = [11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19]
    assert Aretheythesame.comp(a, b) == true
    IO.puts("Test 2")

    assert Aretheythesame.comp(
             [121, 144, 19, 161, 19, 144, 19, 11],
             [11 * 21, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19]
           ) == false

    IO.puts("Test 3")

    assert Aretheythesame.comp(
             [121, 144, 19, 161, 19, 144, 19, 11],
             [11 * 11, 121 * 121, 144 * 144, 190 * 190, 161 * 161, 19 * 19, 144 * 144, 19 * 19]
           ) == false

    IO.puts("Test 4")
    assert Aretheythesame.comp([], []) == true
    IO.puts("Test 5")

    assert Aretheythesame.comp([], [
             11 * 11,
             121 * 121,
             144 * 144,
             190 * 190,
             161 * 161,
             19 * 19,
             144 * 144,
             19 * 19
           ]) == false

    IO.puts("Test 6")

    assert Aretheythesame.comp(
             [121, 144, 19, 161, 19, 144, 19, 11, 1008],
             [11 * 11, 121 * 121, 144 * 144, 190 * 190, 161 * 161, 19 * 19, 144 * 144, 19 * 19]
           ) == false

    IO.puts("Test 7")

    assert Aretheythesame.comp(
             [2, 2, 3],
             [4, 9, 9]
           ) == false

    IO.puts("Test 8")

    assert Aretheythesame.comp(
             [4, 4],
             [1, 31]
           ) == false

    IO.puts("Test 9")

    assert Aretheythesame.comp(
             [3, 4],
             [0, 25]
           ) == false
  end

  def randomtests(n) when n <= 0 do
    IO.puts("Finished!")
  end

  def randomtests(n) do
    IO.puts("Test #{n}")
    a = for _ <- 1..20, do: :random.uniform(100)
    b = Enum.map(a, fn x -> x * x end)
    r = rem(:random.uniform(1000), 7)

    if r < 3 do
      [h | t] = b
      t = t ++ [:random.uniform(1000)]

      IO.puts(Enum.join(a, ", "))
      IO.puts("----")
      IO.puts(Enum.join(t, ", "))

      assert Aretheythesame.comp(a, t) == false
    else
      assert Aretheythesame.comp(a, b) == true
    end

    randomtests(n - 1)
  end

  test "random" do
    IO.puts("\n")
    randomtests(50)
  end
end
