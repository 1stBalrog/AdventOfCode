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
        std::ifstream infile("Day04.txt");

        int current = 0;
        string line;
        while (getline(infile, line))
        {
            size_t seperator = line.find(',', 0);

            string part1 = line.substr(0, seperator);
            string part2 = line.substr(seperator + 1, line.length() - seperator);

            size_t seperator1 = part1.find('-');
            size_t seperator2 = part2.find('-');

            int first1 = stoi(part1.substr(0, seperator1));
            int first2 = stoi(part1.substr(seperator1 + 1, part1.length() - seperator1));

            int second1 = stoi(part2.substr(0, seperator2));
            int second2 = stoi(part2.substr(seperator2 + 1, part2.length() - seperator2));

            if (first1 >= second1 && first2 <= second2)
            {
                current++;
            }
            else if (second1 >= first1 && second2 <= first2)
            {
                current++;
            }
        }

        cout << current;
    }

    void Part2()
    {
        std::ifstream infile("Day04.txt");

        int current = 0;
        string line;
        while (getline(infile, line))
        {
            size_t seperator = line.find(',', 0);

            string part1 = line.substr(0, seperator);
            string part2 = line.substr(seperator + 1, line.length() - seperator);

            size_t seperator1 = part1.find('-');
            size_t seperator2 = part2.find('-');

            int first1 = stoi(part1.substr(0, seperator1));
            int first2 = stoi(part1.substr(seperator1 + 1, part1.length() - seperator1));

            int second1 = stoi(part2.substr(0, seperator2));
            int second2 = stoi(part2.substr(seperator2 + 1, part2.length() - seperator2));

            if (first1 >= second1 && first1 <= second2)
            {
                current++;
            }
            else if (first2 >= second1 && first2 <= second2)
            {
                current++;
            }
            else if (second1 >= first1 && second1 <= first2)
            {
                current++;
            }
            else if (second2 >= first1 && second2 <= first2)
            {
                current++;
            }
        }

        cout << current;
    }
};
