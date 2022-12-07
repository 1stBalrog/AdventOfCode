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
        ifstream infile("Day01.txt");

        vector<int> list;
        int current = 0;
        string line;
        while (getline(infile, line))
        {
            if (line == "")
            {
                list.push_back(current);
                current = 0;
                continue;
            }

            current += stoi(line);
        }
        list.push_back(current);

        int max = 0;
        for (size_t i = 0; i < list.size(); i++)
        {
            if (max < list[i])
            {
                max = list[i];
            }
        }

        cout << max;
    }

    void Part2()
    {
        ifstream infile("Day01.txt");

        vector<int> list;
        int current = 0;
        string line;
        while (getline(infile, line))
        {
            if (line == "")
            {
                list.push_back(current);
                current = 0;
                continue;
            }

            current += stoi(line);
        }
        list.push_back(current);

        sort(list.begin(), list.end(), greater<int>());

        int max = list[0] + list[1] + list[2];

        cout << max;
    }
};
