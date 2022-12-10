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
        ifstream infile("Day09.txt");

        //Start positions
        int headX = 0, headY = 0;
        int tailX = 0, tailY = 0;
        pair<int, int> tailPosOld = make_pair(tailX, tailY);
        pair<int, int> tailPosNew = make_pair(tailX, tailY);
        vector<pair<int, int>> positions;
        positions.push_back(tailPosNew);

        string line;
        while (getline(infile, line))
        {
            string direction = line.substr(0, 1);
            int steps = stoi(line.substr(2, line.size() - 2));

            for (size_t i = 0; i < steps; i++)
            {
                tailPosNew = Move(direction, headX, headY, tailX, tailY);
                if (tailPosNew != tailPosOld)
                {
                    tailPosOld = tailPosNew;
                    positions.push_back(tailPosNew);
                }
            }
        }

        //Unique positions
        vector<pair<int, int>> uPositions;
        for (size_t i = 0; i < positions.size(); i++)
        {
            if (!(std::find(uPositions.begin(), uPositions.end(), positions[i]) != uPositions.end()))
            {
                uPositions.push_back(positions[i]);
            }
        }

        size_t count = uPositions.size();

        cout << count;
    }

    void Part2()
    {
        ifstream infile("Day09.txt");

        //Start positions
        int headX = 0, headY = 0;
        int tailX = 0, tailY = 0;
        pair<int, int> tailPosOld = make_pair(tailX, tailY);
        pair<int, int> tailPosNew = make_pair(tailX, tailY);
        pair<int, int> tailEndPosOld = make_pair(tailX, tailY);
        pair<int, int> tailEndPosNew = make_pair(tailX, tailY);
        vector<pair<int, int>> positions;
        positions.push_back(tailPosNew);

        vector<pair<int, int>> tail;
        for (size_t i = 0; i < 9; i++)
        {
            tail.push_back(make_pair(tailX, tailY));
        }

        string line;
        while (getline(infile, line))
        {
            string direction = line.substr(0, 1);
            int steps = stoi(line.substr(2, line.size() - 2));

            for (size_t i = 0; i < steps; i++)
            {
                tailPosNew = Move(direction, headX, headY, tailX, tailY);
                if (tailPosNew == tailPosOld)
                {
                    continue;
                }

                //Tail moved, update Tail
                tail[0] = tailPosNew;
                tailEndPosNew = UpdateTail(tail);
                if (tailEndPosNew != tailEndPosOld)
                {
                    tailEndPosOld = tailEndPosNew;
                    positions.push_back(tailEndPosNew);
                }
            }
        }

        //Unique positions
        vector<pair<int, int>> uPositions;
        for (size_t i = 0; i < positions.size(); i++)
        {
            if (!(std::find(uPositions.begin(), uPositions.end(), positions[i]) != uPositions.end()))
            {
                uPositions.push_back(positions[i]);
            }
        }

        size_t count = uPositions.size();

        cout << count;
    }

    pair<int, int> Move(string direction, int& headX, int& headY, int& tailX, int& tailY)
    {
        if (direction == "R")
        {
            headX++;
        }
        else if (direction == "L")
        {
            headX--;
        }
        else if (direction == "U")
        {
            headY++;
        }
        else if (direction == "D")
        {
            headY--;
        }

        int x = headX - tailX;
        int y = headY - tailY;

        //Move tail
        if (x == 0 && y == 0)
        {
            //Same position
        }

        else if (x == 2 && y == 0)
        {
            //Right
            tailX++;
        }
        else if (x == -2 && y == 0)
        {
            //Left
            tailX--;
        }
        else if (x == 0 && y == 2)
        {
            //Up
            tailY++;
        }
        else if (x == 0 && y == -2)
        {
            //Down
            tailY--;
        }

        else if ((x == 2 && y == 1) || (x == 1 && y == 2))
        {
            //Right-Up
            tailX++;
            tailY++;
        }
        else if ((x == 2 && y == -1) || (x == 1 && y == -2))
        {
            //Left-Up
            tailX++;
            tailY--;
        }
        else if ((x == -2 && y == 1) || (x == -1 && y == 2))
        {
            //Right-Down
            tailX--;
            tailY++;
        }
        else if ((x == -2 && y == -1) || (x == -1 && y == -2))
        {
            //Left-Down
            tailX--;
            tailY--;
        }

        return make_pair(tailX, tailY);
    }

    pair<int, int> UpdateTail(vector<pair<int, int>>& tail)
    {
        pair<int, int> tailPosOld = tail[0];
        pair<int, int> tailPosNew = tail[0];
        for (size_t i = 1; i < tail.size(); i++)
        {
            tailPosOld = tail[i - 1];
            tailPosNew = tail[i];

            tailPosNew = MoveTail(tailPosOld.first, tailPosOld.second, tailPosNew.first, tailPosNew.second);

            if (tailPosNew != tailPosOld)
            {
                tail[i] = tailPosNew;
            }
        }

        return tail[tail.size() - 1];
    }

    pair<int, int> MoveTail(int headX, int headY, int tailX, int tailY)
    {
        int x = headX - tailX;
        int y = headY - tailY;

        //Move tail
        if (x == 0 && y == 0)
        {
            //Same position
        }

        else if (x == 2 && y == 0)
        {
            //Right
            tailX++;
        }
        else if (x == -2 && y == 0)
        {
            //Left
            tailX--;
        }
        else if (x == 0 && y == 2)
        {
            //Up
            tailY++;
        }
        else if (x == 0 && y == -2)
        {
            //Down
            tailY--;
        }

        else if ((x == 2 && y == 1) || (x == 1 && y == 2) || (x == 2 && y == 2))
        {
            //Right-Up
            tailX++;
            tailY++;
        }
        else if ((x == 2 && y == -1) || (x == 1 && y == -2) || (x == 2 && y == -2))
        {
            //Left-Up
            tailX++;
            tailY--;
        }
        else if ((x == -2 && y == 1) || (x == -1 && y == 2) || (x == -2 && y == 2))
        {
            //Right-Down
            tailX--;
            tailY++;
        }
        else if ((x == -2 && y == -1) || (x == -1 && y == -2) || (x == -2 && y == -2))
        {
            //Left-Down
            tailX--;
            tailY--;
        }

        return make_pair(tailX, tailY);
    }

    void Visualize(vector<pair<int, int>> tail)
    {
        vector<int> xPos;
        vector<int> yPos;
        for (size_t i = 0; i < tail.size(); i++)
        {
            xPos.push_back(tail[i].first);
            yPos.push_back(tail[i].second);
        }

        sort(xPos.begin(), xPos.end());
        sort(yPos.begin(), yPos.end());

        int xMin = xPos[0], xMax = xPos[xPos.size() - 1];
        int yMin = yPos[0], yMax = yPos[yPos.size() - 1];

        for (int j = yMax; j >= yMin; j--)
        {
            for (int i = xMin; i <= xMax; i++)
            {
                if (find(tail.begin(), tail.end(), make_pair(i, j)) != tail.end())
                {
                    cout << "#";
                }
                else
                {
                    cout << ".";
                }
            }
            cout << endl;
        }
    }
};
