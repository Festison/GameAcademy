#include<iostream>
using namespace std;

void PrintMenu()
{
	cout << "-------------" << endl;
	cout << "---Default---" << endl;
	cout << "-------------" << endl;
	cout << endl;
}

void PrintMenu(int i)
{
	cout << "-------------" << endl;
	cout << "----Menu" << i << "----" << endl;
	cout << "-------------" << endl;
	cout << endl;
}

void ShowInventory()
{
	int inventorySize = 10;

	cout << "--------Inventory--------" << endl;

	for (int i = 0; i < inventorySize; i++)
	{
		cout << i << "번 인벤토리 아이템" << endl;
	}

	cout << "--------Inventory--------" << endl;
	cout << endl;
}

void ShowInventory(int index)
{
	cout << index << "번째 인벤토리 아이템" << endl;
	cout << endl;
}

void ShowInventory(float value)
{
	cout << "잘못된 데이터타입 임력됨" << endl;
	cout << endl;
}

void ShowInventory(char ch)
{
	cout << "문자형 데이터 타입 입력" << endl;
	cout << endl;
}

void ShowInventory(bool pro)
{
	cout << "참 또는 거짓" << endl;
	cout << endl;
}

int main()
{
	// 함수 오버로딩 : 함수의 이름이 같아도 매개변수에 따라 다양한 결과가 나오도록 하는 기법
	// 다형성

	PrintMenu();
	PrintMenu(2);
	ShowInventory();
	ShowInventory(8);
	ShowInventory(3.54f);
	ShowInventory('a');
	ShowInventory(true);

	return 0;
}
