def square_digits(num):
    num_string = str(num)

    return int("".join(str(int(num) ** 2) for num in num_string))


print(square_digits(765))
