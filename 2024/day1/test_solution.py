#!/usr/bin/env python3
"""
Test cases for Advent of Code 2024 - Day 1
"""
import pytest
from pathlib import Path
from solution import parse_input, solve_part1, solve_part2

# Example data from the puzzle description
EXAMPLE_INPUT = """3   4
4   3
2   5
1   3
3   9
3   3"""

def test_part1_example(tmp_path):
    # Create a temporary input file with example data
    input_file = tmp_path / "input.txt"
    input_file.write_text(EXAMPLE_INPUT)
    
    # Parse input and solve
    data = parse_input(input_file)
    result = solve_part1(data)
    
    # Verify the result matches the example solution
    assert result == 11

def test_part2_example(tmp_path):
    # Create a temporary input file with example data
    input_file = tmp_path / "input.txt"
    input_file.write_text(EXAMPLE_INPUT)
    
    # Parse input and solve
    data = parse_input(input_file)
    result = solve_part2(data)
    
    # Verify against example solution
    assert result == 31