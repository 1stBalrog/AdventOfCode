#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

struct Operation
{
    bool multiply;
    bool withSelf;
    int value;
};

struct Monkey
{
    vector<long long> items;
    Operation operation;

    int divisor;
    int onTrue;
    int onFalse;

    int inspections = 0;
};

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
        vector<Monkey> monkeyList;
        getList(monkeyList);

        int relief = 3;

        for (size_t i = 0; i < 20; i++)
        {
            for (size_t j = 0; j < monkeyList.size(); j++)
            {
                Monkey monkey = monkeyList[j];
                for (size_t k = 0; k < monkey.items.size(); k++)
                {
                    monkeyList[j].inspections++;
                    long long item = monkey.items[k];
                    long long val;

                    if (monkey.operation.withSelf)
                    {
                        val = item;
                    }
                    else
                    {
                        val = monkey.operation.value;
                    }

                    if (monkey.operation.multiply)
                    {
                        item *= val;
                    }
                    else
                    {
                        item += val;
                    }

                    //Apply relief
                    item /= relief;

                    int throwTo;
                    if (item % monkey.divisor == 0)
                    {
                        throwTo = monkey.onTrue;
                    }
                    else
                    {
                        throwTo = monkey.onFalse;
                    }
                    monkeyList[throwTo].items.push_back(item);
                }
                monkeyList[j].items.clear();
            }
        }

        vector<int> inspections;
        for (size_t i = 0; i < monkeyList.size(); i++)
        {
            inspections.push_back(monkeyList[i].inspections);
        }

        sort(inspections.begin(), inspections.end(), greater<int>());

        int result = inspections[0] * inspections[1];
        cout << result;
    }

    void Part2()
    {
        vector<Monkey> monkeyList;
        getList(monkeyList);

        int relief = 1;
        for (size_t i = 0; i < monkeyList.size(); i++)
        {
            relief *= monkeyList[i].divisor;
        }

        for (size_t i = 0; i < 10000; i++)
        {
            for (size_t j = 0; j < monkeyList.size(); j++)
            {
                Monkey monkey = monkeyList[j];
                for (size_t k = 0; k < monkey.items.size(); k++)
                {
                    monkeyList[j].inspections++;
                    long long item = monkey.items[k];
                    long long val;

                    if (monkey.operation.withSelf)
                    {
                        val = item;
                    }
                    else
                    {
                        val = monkey.operation.value;
                    }

                    if (monkey.operation.multiply)
                    {
                        item *= val;
                    }
                    else
                    {
                        item += val;
                    }

                    //Apply relief
                    item %= relief;

                    int throwTo;
                    if (item % monkey.divisor == 0)
                    {
                        throwTo = monkey.onTrue;
                    }
                    else
                    {
                        throwTo = monkey.onFalse;
                    }
                    monkeyList[throwTo].items.push_back(item);
                }
                monkeyList[j].items.clear();
            }
        }

        vector<long long> inspections;
        for (size_t i = 0; i < monkeyList.size(); i++)
        {
            inspections.push_back(monkeyList[i].inspections);
        }

        sort(inspections.begin(), inspections.end(), greater<long long>());

        long long result = inspections[0] * inspections[1];
        cout << result;
    }

    void getList(vector<Monkey>& monkeyList)
    {
        ifstream infile("Day11.txt");

        Monkey monkey;
        string line;
        int currentLine = 0;
        while (getline(infile, line))
        {
            currentLine++;
            if (currentLine == 1)
            {
                //Monkey-Name
            }
            else if (currentLine == 2)
            {
                //Starting items
                string text = "  Starting items: ";
                string part = line.substr(text.size());
                vector<string> parts;
                splitString(part, ", ", parts);
                for (size_t i = 0; i < parts.size(); i++)
                {
                    monkey.items.push_back(stoi(parts[i]));
                }
            }
            else if (currentLine == 3)
            {
                //Operation
                string text = "  Operation: new = old ";
                string part = line.substr(text.size());

                monkey.operation.multiply = part.substr(0, 1) == "*";
                string val = part.substr(2, part.size() - 2);
                if (val == "old")
                {
                    monkey.operation.withSelf = true;
                }
                else
                {
                    monkey.operation.withSelf = false;
                    monkey.operation.value = stoi(val);
                }
            }
            else if (currentLine == 4)
            {
                //Test
                string text = "  Test: divisible by ";
                string part = line.substr(text.size());
                monkey.divisor = stoi(part);
            }
            else if (currentLine == 5)
            {
                //OnTrue
                string text = "    If true: throw to monkey ";
                string part = line.substr(text.size());
                monkey.onTrue = stoi(part);
            }
            else if (currentLine == 6)
            {
                //OnFalse
                string text = "    If false: throw to monkey ";
                string part = line.substr(text.size());
                monkey.onFalse = stoi(part);
            }
            else
            {
                monkeyList.push_back(monkey);
                monkey = {};
                currentLine = 0;
            }
        }
        monkeyList.push_back(monkey);
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