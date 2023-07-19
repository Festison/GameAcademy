#include<iostream>
#include<algorithm>
using namespace std;

// Àü¹æ ¼±¾ð
void Gugudan();
void Gugudan(int dan);
int Gugudan(int numA, int numB);

int main()
{
	Gugudan();
	Gugudan(5);
	cout << Gugudan(5, 5) << endl;
}

void Gugudan(int dan)
{
	for (int i = 1; i < 10; i++)
	{
		cout << dan << " * " << i << " = " << dan * i << endl;
	}

	cout << endl;
}

void Gugudan()
{
	for (int i = 1; i < 10; i++)
	{
		Gugudan(i);
	}

	cout << endl;
}

int Gugudan(int numA, int numB)
{
	cout << numA << " * " << numB << " = ";

	return numA * numB;
}

