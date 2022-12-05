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
        std::ifstream infile("Day03.txt");

        int current = 0;
        string line;
        while (getline(infile, line))
        {
            int half = line.length() / 2;

            string first = line.substr(0, half);
            string second = line.substr(half, half);

            for (size_t i = 0; i < first.length(); i++)
            {
                char c = first[i];
                int found = second.find(c, 0);
                if (found == -1)
                {
                    continue;
                }

                int val = (int)c;
                if (val > 96)
                {
                    // a = '97' -> 1
                    val -= 96;
                }
                else
                {
                    // A = '65' -> 27
                    val -= 65 - 27;
                }

                current += val;
                break;
            }
        }

        cout << current;
    }

    void Part2()
    {
        std::ifstream infile("Day03.txt");

        int current = 0;
        string line;
        vector<string> list;
        while (getline(infile, line))
        {
            list.push_back(line);
        }

        for (size_t i = 0; i < list.size(); i += 3)
        {
            int half = line.length() / 2;

            string first = list[i];
            string second = list[i + 1];
            string third = list[i + 2];

            for (size_t j = 0; j < first.length(); j++)
            {
                char c = first[j];
                int found1 = second.find(c, 0);
                int found2 = third.find(c, 0);
                if (found1 == -1 || found2 == -1)
                {
                    continue;
                }

                int val = (int)c;
                if (val > 96)
                {
                    // a = '97' -> 1
                    val -= 96;
                }
                else
                {
                    // A = '65' -> 27
                    val -= 65 - 27;
                }

                current += val;
                break;
            }
        }

        cout << current;
    }
};