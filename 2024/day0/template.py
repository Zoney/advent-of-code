#!/usr/bin/env python3
"""
Advent of Code Template
"""
from pathlib import Path
from typing import Any, List

def parse_input(input_path: Path) -> Any:
    """Parse the puzzle input.
    
    Modify this function to parse the input according to the puzzle rules.
    Consider different input formats:
    - Line by line: `return [line.strip() for line in f]`
    - Single string: `return f.read().strip()`
    - Paragraphs: `return f.read().strip().split('\n\n')`
    """
    with open(input_path) as f:
        # TODO: Implement parsing logic
        return [line.strip() for line in f if line.strip()]

def solve_part1(data: Any) -> Any:
    """Solve part 1 of the puzzle.
    
    Args:
        data: Parsed puzzle input

    Returns:
        Solution to part 1
    """
    # TODO: Implement part 1 solution
    pass

def solve_part2(data: Any) -> Any:
    """Solve part 2 of the puzzle.
    
    Args:
        data: Parsed puzzle input

    Returns:
        Solution to part 2
    """
    # TODO: Implement part 2 solution
    pass

def main() -> None:
    """Main function to solve both parts of the puzzle."""
    # Get input file from the same directory as this script
    input_path = Path(__file__).parent / "input.txt"
    
    # Parse input
    data = parse_input(input_path)
    
    # Solve parts
    part1_result = solve_part1(data)
    print(f"Part 1: {part1_result}")
    
    part2_result = solve_part2(data)
    print(f"Part 2: {part2_result}")

if __name__ == "__main__":
    main() 