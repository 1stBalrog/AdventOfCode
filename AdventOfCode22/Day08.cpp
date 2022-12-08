#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

class Day
{
public:
    void Solve()
    {
        Part1();
        cout << endl;
        Part2();
    }

    void Part1()
    {
        ifstream infile("Day08.txt");

        vector<vector<short>> grid;
        string line;
        while (getline(infile, line))
        {
            vector<short> row;
            for (size_t i = 0; i < line.size(); i++)
            {
                row.push_back((short)stoi(line.substr(i, 1)));
            }
            grid.push_back(row);
        }

        size_t totalSum = 0;

        size_t rows = grid.size();
        size_t cols = grid[0].size();
        totalSum += rows * 2 + cols * 2 - 4;

        bool visible = checkGrid(1, 1, grid, rows, cols);

        for (size_t i = 1; i < grid.size() - 1; i++)
        {
            for (size_t j = 1; j < grid[i].size() - 1; j++)
            {
                if (checkGrid(i, j, grid, rows, cols))
                {
                    totalSum++;
                }
            }
        }

        cout << totalSum;
    }

    void Part2()
    {
        ifstream infile("Day08.txt");

        vector<vector<short>> grid;
        string line;
        while (getline(infile, line))
        {
            vector<short> row;
            for (size_t i = 0; i < line.size(); i++)
            {
                row.push_back((short)stoi(line.substr(i, 1)));
            }
            grid.push_back(row);
        }

        size_t rows = grid.size();
        size_t cols = grid[0].size();

        vector<size_t> scores;
        for (size_t i = 1; i < grid.size() - 1; i++)
        {
            for (size_t j = 1; j < grid[i].size() - 1; j++)
            {
                size_t scenicScore = getScenicScore(i, j, grid, rows, cols);
                scores.push_back(scenicScore);
            }
        }

        sort(scores.begin(), scores.end(), greater<size_t>());

        size_t totalSum = scores[0];
        cout << totalSum;
    }

    bool checkGrid(size_t row, size_t col, vector<vector<short>> grid, size_t rows, size_t cols)
    {
        //Left
        bool left = true;
        for (size_t i = 0; i < col; i++)
        {
            if (grid[row][i] >= grid[row][col])
            {
                left = false;
                break;
            }
        }

        //Right
        bool right = true;
        for (size_t i = col + 1; i < cols; i++)
        {
            if (grid[row][i] >= grid[row][col])
            {
                right = false;
                break;
            }
        }

        //Up
        bool up = true;
        for (size_t i = 0; i < row; i++)
        {
            if (grid[i][col] >= grid[row][col])
            {
                up = false;
                break;
            }
        }

        //Down
        bool down = true;
        for (size_t i = row + 1; i < rows; i++)
        {
            if (grid[i][col] >= grid[row][col])
            {
                down = false;
                break;
            }
        }

        return left || right || up || down;
    }

    size_t getScenicScore(size_t row, size_t col, vector<vector<short>> grid, size_t rows, size_t cols)
    {
        size_t left = 0, right = 0, up = 0, down = 0;

        //Left
        for (size_t i = col; i > 0; i--)
        {
            left++;
            if (grid[row][i - 1] >= grid[row][col])
            {
                break;
            }
        }

        //Right
        for (size_t i = col + 1; i < cols; i++)
        {
            right++;
            if (grid[row][i] >= grid[row][col])
            {
                break;
            }
        }

        //Up
        for (size_t i = row; i > 0; i--)
        {
            up++;
            if (grid[i - 1][col] >= grid[row][col])
            {
                break;
            }
        }

        //Down
        for (size_t i = row + 1; i < rows; i++)
        {
            down++;
            if (grid[i][col] >= grid[row][col])
            {
                break;
            }
        }

        return left * right * up * down;
    }
};