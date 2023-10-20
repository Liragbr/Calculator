def addition(numbers):
    return sum(numbers)

def subtraction(numbers):
    result = numbers[0]
    for num in numbers[1:]:
        result -= num
    return result

def multiplication(numbers):
    result = 1
    for num in numbers:
        result *= num
    return result

def division(numbers):
    result = numbers[0]
    for num in numbers[1:]:
        if num == 0:
            raise ValueError("Cannot divide by zero")
        result /= num
    return result

def factorial(number):
    if number < 0:
        raise ValueError("Cannot calculate factorial of a negative number")
    if number == 0:
        return 1
    else:
        return number * factorial(number - 1)

def square_root(number):
    if number < 0:
        raise ValueError("Cannot calculate square root of a negative number")
    
    if number == 0:
        return 0
    
    x = number
    while True:
        next_x = 0.5 * (x + number / x)
        if abs(x - next_x) < 1e-9:
            return next_x
        x = next_x

result = None 
numbers = []

while True:
    print("Scientific Calculator")
    print("1. Addition")
    print("2. Subtraction")
    print("3. Multiplication")
    print("4. Division")
    print("5. Factorial")
    print("6. Square Root")
    print("7. Exit")

    choice = input("\n(1/2/3/4/5/6/7)\nChoose the desired operation: ")

    if choice == '7':
        print("Exiting the calculator.")
        break

    if choice not in ('1', '2', '3', '4', '5', '6'):
        print("\nInvalid operation. Please choose a valid option (1/2/3/4/5/6/7).\n")
        continue

    if choice != '5' and choice != '6':
        try:
            numbers = []
            while True:
                print("(leave blank to end input)")
                num = input("Enter a number: ")
                if num == "":
                    break
                numbers.append(float(num))
        except ValueError:
            print("Invalid input. Please make sure you entered valid numbers.")
            continue

    if choice == '1':
        result = addition(numbers)
    elif choice == '2':
        result = subtraction(numbers)
    elif choice == '3':
        result = multiplication(numbers)
    elif choice == '4':
        try:
            result = division(numbers)
        except ValueError as e:
            print(e)
            continue
    elif choice == '5':
        num = float(input("Enter a number for factorial: "))
        result = factorial(int(num))
    elif choice == '6':
        num = float(input("Enter a number for square root: "))
        try:
            result = square_root(num)
        except ValueError as e:
            print(e)
            continue

    print(f"\nResult is: {result}\n")