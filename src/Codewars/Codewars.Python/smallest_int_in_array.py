def find_smallest_int(arr):
    smallest_int = float("inf")

    for x in arr:
        if x < smallest_int:
            smallest_int = x

    return smallest_int