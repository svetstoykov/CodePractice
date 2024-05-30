def get_count(sentence):
    return sum(1 for x in sentence if x in "aeiou")
        