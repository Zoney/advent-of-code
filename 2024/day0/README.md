# Day 0 - Demo Structure

This is a demo folder showing the recommended structure for Advent of Code solutions.

## Files
- `solution.py`: Main solution file with typed functions and docstrings
- `test_solution.py`: Test file using pytest with fixtures
- `input.txt`: Input data file
- `problem.txt`: Problem description in Advent of Code style
- `template.py`: Template file for solving future puzzles

## Demo Problem
This demo implements a simple two-part problem:
1. Part 1: Find the sum of all even numbers in the input
2. Part 2: Find the product of all numbers greater than the mean

## Running Tests
From this directory:
```bash
pytest test_solution.py -v
```

## Running Solution
From this directory:
```bash
python solution.py
```

## Starting a New Day
1. Create a new directory for the day
2. Copy `template.py` to the new directory
3. Create `input.txt` with your puzzle input
4. Implement the solution
5. Create tests as needed

## Code Quality
The project is set up with:
- Type hints and mypy for type checking
- Black for code formatting
- isort for import sorting
- pytest for testing

You can run these tools using:
```bash
mypy solution.py
black .
isort .
``` 