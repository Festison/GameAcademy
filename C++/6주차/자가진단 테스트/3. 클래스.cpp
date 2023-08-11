#include <iostream>
using namespace std;
#include "Player.h"

#define KNIGHT_MIN_COUNT 1

const int KNIGHT_COUNT = 10;

int main()
{
	Knight* knights[KNIGHT_COUNT];

	for (int i = 0; i < KNIGHT_COUNT; i++)
	{
		if (i % 2 == 0)
		{
			knights[i] = new Knight();
		}
		else
		{
			knights[i] = new Knight(200);
		}
	}

	for (int i = 0; i < KNIGHT_COUNT; i++)
	{
		knights[i]->PrintInfo();
		delete knights[i];
	}

	int k = 0;

	try
	{
		if (k==0)
		{
			throw 1;
		}
	}
	catch (float asd)
	{
		cout << asd << endl;
	}
	
}
