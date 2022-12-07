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
        ifstream infile("Day05.txt");

        string line;
        bool instructions = false;
        vector<string> stackList;
        vector<string> instructionList;
        while (getline(infile, line))
        {
            if (line == "")
            {
                instructions = true;
                continue;
            }

            if (instructions)
            {
                instructionList.push_back(line);
            }
            else
            {
                stackList.push_back(line);
            }
        }

        size_t stackCount = (stackList[0].size() + 1) / 4;
        vector<vector<char>> stacks;
        for (size_t i = 0; i < stackCount; i++)
        {
            vector<char> empty;
            stacks.push_back(empty);
        }

        for (size_t i = stackList.size() - 1; i > 0; i--)
        {
            string line = stackList[i - 1];
            size_t size = line.size() + 1;
            for (size_t j = 0; j < size / 4; j++)
            {
                char part = line.substr(j * 4, 2)[1];
                if (part != ' ')
                {
                    stacks[j].push_back(part);
                }
            }
        }

        for (size_t i = 0; i < instructionList.size(); i++)
        {
            string line = instructionList[i];
            vector<std::string> parts;
            splitString(line, " ", parts);

            int amount = stoi(parts[1]);
            int origin = stoi(parts[3]) - 1;
            int destin = stoi(parts[5]) - 1;

            for (size_t j = 0; j < amount; j++)
            {
                stacks[destin].push_back(stacks[origin][stacks[origin].size() - 1]);
                stacks[origin].pop_back();
            }
        }

        string result;
        for (size_t i = 0; i < stacks.size(); i++)
        {
            result += stacks[i][stacks[i].size() - 1];
        }

        cout << result;
    }

    void Part2()
    {
        ifstream infile("Day05.txt");

        string line;
        bool instructions = false;
        vector<string> stackList;
        vector<string> instructionList;
        while (getline(infile, line))
        {
            if (line == "")
            {
                instructions = true;
                continue;
            }

            if (instructions)
            {
                instructionList.push_back(line);
            }
            else
            {
                stackList.push_back(line);
            }
        }

        size_t stackCount = (stackList[0].size() + 1) / 4;
        vector<vector<char>> stacks;
        for (size_t i = 0; i < stackCount; i++)
        {
            vector<char> empty;
            stacks.push_back(empty);
        }

        for (size_t i = stackList.size() - 1; i > 0; i--)
        {
            string line = stackList[i - 1];
            size_t size = line.size() + 1;
            for (size_t j = 0; j < size / 4; j++)
            {
                char part = line.substr(j * 4, 2)[1];
                if (part != ' ')
                {
                    stacks[j].push_back(part);
                }
            }
        }

        for (size_t i = 0; i < instructionList.size(); i++)
        {
            string line = instructionList[i];
            vector<std::string> parts;
            splitString(line, " ", parts);

            int amount = stoi(parts[1]);
            int origin = stoi(parts[3]) - 1;
            int destin = stoi(parts[5]) - 1;

            vector<char> cranePick;
            for (size_t j = 0; j < amount; j++)
            {
                cranePick.push_back(stacks[origin][stacks[origin].size() - 1]);
                stacks[origin].pop_back();
            }

            for (size_t j = cranePick.size(); j > 0; j--)
            {
                stacks[destin].push_back(cranePick[j - 1]);
            }
        }

        string result;
        for (size_t i = 0; i < stacks.size(); i++)
        {
            result += stacks[i][stacks[i].size() - 1];
        }

        cout << result;
    }

    void splitString(string str, string delimiter, vector<string>& out)
    {
        size_t start = 0;
        size_t end = str.find(delimiter);
        while (end != -1)
        {
            out.push_back(str.substr(start, end - start));
            start = end + delimiter.size();
            end = str.find(delimiter, start);
        }
        out.push_back(str.substr(start, end - start));
    }
};
