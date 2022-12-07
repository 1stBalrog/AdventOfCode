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
        ifstream infile("Day06.txt");

        size_t current = 0;
        string line;
        getline(infile, line);

        //initialize stack
        vector<char> stack;
        for (size_t i = 0; i < 4; i++)
        {
            stack.push_back(line[i]);
        }

        for (size_t i = 3; i < line.size(); i++)
        {
            size_t index = i % 4;
            stack[index] = line[i];

            if (checkStack(stack))
            {
                continue;
            }

            current = i + 1;
            break;
        }

        cout << current;
    }

    void Part2()
    {
        ifstream infile("Day06.txt");

        size_t current = 0;
        string line;
        getline(infile, line);

        //initialize stack
        vector<char> stack;
        for (size_t i = 0; i < 14; i++)
        {
            stack.push_back(line[i]);
        }

        for (size_t i = 13; i < line.size(); i++)
        {
            size_t index = i % 14;
            stack[index] = line[i];

            if (checkStack(stack))
            {
                continue;
            }

            current = i + 1;
            break;
        }

        cout << current;
    }

    bool checkStack(vector<char> stack)
    {
        for (size_t i = 0; i < stack.size(); i++)
        {
            for (size_t j = 0; j < stack.size(); j++)
            {
                if (i == j)
                    continue;

                if (stack[i] == stack[j])
                    return true;
            }
        }

        return false;
    }
};
