#!/usr/bin/env python3
"""
Advent of Code 2024 - Day 1: Historian Hysteria
"""
from pathlib import Path
from typing import List, Tuple
from collections import Counter

def parse_input(input_path: Path) -> List[Tuple[int, int]]:
    """Parse the puzzle input into pairs of numbers.
    
    Returns a list of tuples, where each tuple contains a number from the left list
    and a number from the right list.
    """
    with open(input_path) as f:
        lines = [line.strip() for line in f if line.strip()]
        pairs = []
        for line in lines:
            left, right = map(int, line.split())
            pairs.append((left, right))
        return pairs

def solve_part1(data: List[Tuple[int, int]]) -> int:
    """Solve part 1: Find the total distance between sorted pairs.
    
    Args:
        data: List of number pairs from left and right lists

    Returns:
        Total distance between sorted pairs
    """
    # Extract and sort both lists separately
    left_list = sorted([pair[0] for pair in data])
    right_list = sorted([pair[1] for pair in data])
    
    # Calculate total distance between paired numbers
    total_distance = sum(abs(left - right) for left, right in zip(left_list, right_list))
    return total_distance

def solve_part2(data: List[Tuple[int, int]]) -> int:
    """Solve part 2: Calculate similarity score.
    
    For each number in the left list, multiply it by how many times it appears
    in the right list, then sum all these products.
    
    Args:
        data: List of number pairs from left and right lists

    Returns:
        Total similarity score
    """
    # Get both lists
    left_list = [pair[0] for pair in data]
    right_list = [pair[1] for pair in data]
    
    # Count occurrences in right list
    right_counts = Counter(right_list)
    
    # Calculate similarity score
    similarity_score = sum(num * right_counts[num] for num in left_list)
    return similarity_score

def main() -> None:
    """Main function to solve both parts of the puzzle."""
    input_path = Path(__file__).parent / "input.txt"
    data = parse_input(input_path)
    
    part1_result = solve_part1(data)
    print(f"Part 1: {part1_result}")
    
    part2_result = solve_part2(data)
    print(f"Part 2: {part2_result}")

if __name__ == "__main__":
    main() 