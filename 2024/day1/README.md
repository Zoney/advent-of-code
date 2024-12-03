# Day 1: Historian Hysteria

## Part 1

The Chief Historian is missing, and the Senior Historians need help finding him! They need to check historically significant locations, but their lists don't match up. Your task is to help them reconcile their lists.

The puzzle involves comparing two lists of location IDs. The process is:
1. Sort both lists independently
2. Pair up numbers in order (smallest with smallest, etc.)
3. Calculate the distance (absolute difference) between each pair
4. Sum up all the distances

### Example

Given these two lists:
```
Left   Right
3      4
4      3
2      5
1      3
3      9
3      3
```

After sorting and pairing:
1. 1 and 3: distance = 2
2. 2 and 3: distance = 1
3. 3 and 3: distance = 0
4. 3 and 4: distance = 1
5. 3 and 5: distance = 2
6. 4 and 9: distance = 5

Total distance = 11

## Part 2

[To be revealed after completing Part 1] 