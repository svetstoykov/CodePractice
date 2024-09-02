defmodule Square do
  def square?(n) when n >= 0 do
    square = :math.sqrt(n)

    square == Float.floor(square)
  end

  def square?(n) when n< 0 do
    false
  end
end
