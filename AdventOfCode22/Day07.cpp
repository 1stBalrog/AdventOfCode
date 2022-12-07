#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

class Day
{
    class Item
    {
    public:
        Item(string name)
            : Item(name, 0)
        {
            IsDirectory = true;
        }

        Item(string name, size_t size)
        {
            Name = name;
            Size = size;
            IsDirectory = false;
        }

        string Name;
        size_t Size;
        bool IsDirectory;
        vector<Item*> ItemList;
    };

public:
    void Solve()
    {
        Part1();
        cout << endl;
        Part2();
    }

    void Part1()
    {
        Item* rootDir = readFile();

        calculateAll(rootDir);

        size_t totalSum = 0;
        calculateTotal(rootDir, totalSum);

        cout << totalSum;
    }

    void Part2()
    {
        Item* rootDir = readFile();

        calculateAll(rootDir);

        vector<size_t> list;
        convertList(rootDir, list);

        sort(list.begin(), list.end(), greater<size_t>());

        size_t totalSpace = 70000000;
        size_t requiredSpace = 30000000;
        size_t currentSpace = totalSpace - list[0];

        size_t bestChoice = list[0];
        for (size_t i = 0; i < list.size(); i++)
        {
            if (currentSpace + list[i] > requiredSpace)
            {
                bestChoice = list[i];
                continue;
            }
            break;
        }

        cout << bestChoice;
    }

    Item* readFile()
    {
        ifstream infile("Day07.txt");

        string line;

        //First line is $ cd /
        getline(infile, line);
        Item* rootDir = new Item("/");
        vector<Item*> tmpStack;
        tmpStack.push_back(rootDir);

        Item* currentDir = rootDir;

        while (getline(infile, line))
        {
            //Instruction
            if (line[0] == '$')
            {
                string sub = line.substr(0, 4);
                if (sub == "$ cd")
                {
                    string newDir = line.substr(5, line.size() - 5);
                    if (newDir == "..")
                    {
                        Item* prev = tmpStack[tmpStack.size() - 2];
                        tmpStack.pop_back();
                        currentDir = prev;
                        continue;
                    }

                    Item* subDir = new Item(newDir);
                    currentDir->ItemList.push_back(subDir);
                    currentDir = subDir;
                    tmpStack.push_back(currentDir);
                }
                else if (sub == "$ ls")
                {
                    //Ignore and Fill currentDirectory with the items
                }
                continue;
            }

            if (line[0] == 'd')
            {
                //Directory
            }
            else
            {
                size_t split = line.find(' ');
                string part1 = line.substr(0, split);
                string part2 = line.substr(split + 1, line.size() - split - 1);
                int num = stoi(part1);

                currentDir->ItemList.push_back(new Item(part2, num));
            }
        }

        return rootDir;
    }

    void calculateAll(Item* dir)
    {
        for (size_t i = 0; i < dir->ItemList.size(); i++)
        {
            Item* item = dir->ItemList[i];
            if (item->IsDirectory)
            {
                calculateAll(item);
            }
            dir->Size += item->Size;
        }
    }

    void calculateTotal(Item* dir, size_t& sum)
    {
        for (size_t i = 0; i < dir->ItemList.size(); i++)
        {
            Item* item = dir->ItemList[i];
            if (item->IsDirectory)
            {
                calculateTotal(item, sum);
            }
        }

        if (dir->Size <= 100000)
        {
            sum += dir->Size;
        }
    }

    void convertList(Item* dir, vector<size_t> &list)
    {
        for (size_t i = 0; i < dir->ItemList.size(); i++)
        {
            Item* item = dir->ItemList[i];
            if (item->IsDirectory)
            {
                convertList(item, list);
            }
        }

        list.push_back(dir->Size);
    }
};