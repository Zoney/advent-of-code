from pathlib import Path
from typing import List

def parse_input(input_path: Path) -> List[int]:
    """Parse the input file containing numbers separated by newlines.
    
    Args:
        input_path: Path to input file
        
    Returns:
        List of integers from the input file
    """
    with open(input_path) as f:
        return [int(line.strip()) for line in f if line.strip()]

def solve_part1(numbers: List[int]) -> int:
    """Find the sum of all even numbers in the list.
    
    Args:
        numbers: List of integers to process
        
    Returns:
        Sum of all even numbers
    """
    return sum(num for num in numbers if num % 2 == 0)

def solve_part2(numbers: List[int]) -> int:
    """Find the product of all numbers greater than the mean.
    
    Args:
        numbers: List of integers to process
        
    Returns:
        Product of all numbers greater than the mean
    """
    mean = sum(numbers) / len(numbers)
    result = 1
    for num in numbers:
        if num > mean:
            result *= num
    return result

if __name__ == "__main__":
    input_path = Path(__file__).parent / "input.txt"
    numbers = parse_input(input_path)
    
    part1_result = solve_part1(numbers)
    print(f"Part 1: {part1_result}")
    
    part2_result = solve_part2(numbers)
    print(f"Part 2: {part2_result}") 