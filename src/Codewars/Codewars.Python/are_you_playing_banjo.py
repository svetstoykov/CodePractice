def are_you_playing_banjo(name):
    return (
        name + " plays banjo"
        if name.lower().startswith("r")
        else name + " does not play banjo"
    )


print(are_you_playing_banjo("RIvan"))
