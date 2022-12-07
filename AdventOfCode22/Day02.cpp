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
        ifstream infile("Day02.txt");

        int current = 0;
        string line;
        while (getline(infile, line))
        {
            if (line == "A X")      //Rock Rock
                current += 3 + 1;
            else if (line == "A Y") //Rock Paper
                current += 6 + 2;
            else if (line == "A Z") //Rock Scissors
                current += 0 + 3;

            else if (line == "B X") //Paper Rock
                current += 0 + 1;
            else if (line == "B Y") //Paper Paper
                current += 3 + 2;
            else if (line == "B Z") //Paper Scissors
                current += 6 + 3;

            else if (line == "C X") //Scissors Rock
                current += 6 + 1;
            else if (line == "C Y") //Scissors Paper
                current += 0 + 2;
            else if (line == "C Z") //Scissors Scissors
                current += 3 + 3;
        }

        cout << current;
    }

    void Part2()
    {
        ifstream infile("Day02.txt");

        int current = 0;
        string line;
        while (getline(infile, line))
        {
            if (line == "A X")      //Rock      Loose
                current += 0 + 3;
            else if (line == "A Y") //Rock      Draw
                current += 3 + 1;
            else if (line == "A Z") //Rock      Win
                current += 6 + 2;

            else if (line == "B X") //Paper     Loose
                current += 0 + 1;
            else if (line == "B Y") //Paper     Draw
                current += 3 + 2;
            else if (line == "B Z") //Paper     Win
                current += 6 + 3;

            else if (line == "C X") //Scissors  Loose
                current += 0 + 2;
            else if (line == "C Y") //Scissors  Draw
                current += 3 + 3;
            else if (line == "C Z") //Scissors  Win
                current += 6 + 1;
        }

        cout << current;
    }
};