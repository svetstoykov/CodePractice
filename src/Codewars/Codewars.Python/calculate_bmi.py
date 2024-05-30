def bmi(weight, height):    
    bmi = weight / height**2
    
    print(bmi)

    if bmi <= 18.5:
        return "Underweight"
    if bmi <= 25.0:
        return "Normal"
    if bmi <= 30.0:
        return "Overweight"

    return "Obese"

bmi(50, 1.50)