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
        ifstream infile("Day10.txt");

        vector<Operation> operationList;

        string line;
        Operation buffer{};
        buffer.CycleCount = 0;
        buffer.Value = 0;
        int total = 0;
        int current = 1;
        int cycle = 0;
        bool eol = false;

        //Endless loop for operations
        while (true)
        {
            //Calculate total after 20th and every 40th after that:
            //20, 60, 100, 140, 180, and so on
            if ((++cycle + 20) % 40 == 0)
            {
                total += cycle * current;
            }

            if (buffer.CycleCount == 0)
            {
                if (getline(infile, line))
                {
                    //New Operation
                    string op = line.substr(0, 4);
                    int val;
                    int cycleCount;
                    if (op == "noop")
                    {
                        val = 0;
                        cycleCount = 1;
                    }
                    else
                    {
                        val = stoi(line.substr(5, line.size() - 5));
                        cycleCount = 2;
                    }

                    buffer.CycleCount = cycleCount;
                    buffer.Value = val;
                }
                else
                {
                    break;
                }
            }

            buffer.CycleCount--;

            if (buffer.CycleCount == 0)
            {
                current += buffer.Value;
            }
        }

        cout << total;
    }

    void Part2()
    {
        ifstream infile("Day10.txt");

        vector<Operation> operationList;

        string line;
        Operation buffer{};
        buffer.CycleCount = 0;
        buffer.Value = 0;
        int total = 0;
        int current = 1;
        int cycle = -1;
        bool eol = false;

        //Endless loop for operations
        while (true)
        {
            //Calculate total after 20th and every 40th after that:
            //20, 60, 100, 140, 180, and so on
            if ((++cycle) % 40 == 0)
            {
                cycle = 0;
            }

            if (buffer.CycleCount == 0)
            {
                if (getline(infile, line))
                {
                    //New Operation
                    string op = line.substr(0, 4);
                    int val;
                    int cycleCount;
                    if (op == "noop")
                    {
                        val = 0;
                        cycleCount = 1;
                    }
                    else
                    {
                        val = stoi(line.substr(5, line.size() - 5));
                        cycleCount = 2;
                    }

                    buffer.CycleCount = cycleCount;
                    buffer.Value = val;
                }
                else
                {
                    break;
                }
            }

            buffer.CycleCount--;

            if (buffer.CycleCount == 0)
            {
                current += buffer.Value;
            }
        }

        cout << total;
    }

    class Operation
    {
    public:
        int Value;
        int CycleCount;
    };
};
