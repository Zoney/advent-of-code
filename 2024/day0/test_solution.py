import pytest
from pathlib import Path
from solution import parse_input, solve_part1, solve_part2

@pytest.fixture
def sample_input(tmp_path) -> Path:
    """Create a temporary input file with sample data."""
    input_file = tmp_path / "input.txt"
    input_file.write_text("1\n2\n3\n4\n5\n")
    return input_file

@pytest.fixture
def sample_numbers() -> list[int]:
    """Return a list of sample numbers for testing."""
    return [1, 2, 3, 4, 5]

def test_parse_input(sample_input, sample_numbers):
    """Test that input is correctly parsed."""
    assert parse_input(sample_input) == sample_numbers

def test_solve_part1(sample_numbers):
    """Test that part 1 correctly sums even numbers."""
    assert solve_part1(sample_numbers) == 6  # 2 + 4

def test_solve_part2(sample_numbers):
    """Test that part 2 correctly multiplies numbers above mean."""
    # mean is 3, so multiply 4 and 5
    assert solve_part2(sample_numbers) == 20  # 4 * 5 