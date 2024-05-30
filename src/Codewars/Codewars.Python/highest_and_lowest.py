def high_and_low(numbers):
    lowest = float("inf")
    highest = float("-inf")

    for x in numbers.split(" "):
        num = int(x)

        if num > highest:
            highest = num

        if num < lowest:
            lowest = num

    return f'{highest} {lowest}'
