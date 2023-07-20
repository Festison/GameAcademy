#include <iostream>

using namespace std;

struct Item
{
	string name;
	string toolTip;
	int price;

	void PrintInfo()
	{
		cout << "이름 : " << name << endl;
		cout << "툴팁 : " << toolTip << endl;
		cout << "가격 : " << price << endl;
	}
};

struct Inventory
{
	Item* itemPtr[10];
	int count = 0;

	void PrintInventory()
	{
		for (int i = 0; i < count; i++)
		{
			cout << i << "번째 아이템 설명" << endl;
			itemPtr[i]->PrintInfo();
		}
	}

	void AddItem(Item item, string name, string toolTip, int price)
	{
		if (count >= 10)
		{
			count = 9;
			cout << "인벤토리가 꽉찼습니다" << endl;
			return;
		}

		itemPtr[count] = new Item;
		*itemPtr[count] = item;
		count++;
	}

	~Inventory() //~구조체명()   소멸자
	{
		for (int i = 0; i < count; i++)
		{
			delete itemPtr[i];
		}
	}
};

int main()
{
	Inventory inven;
	Item item1;


	inven.AddItem(item1, item1.name = "포션", item1.toolTip = "포션입니다.", item1.price = 100);

	inven.PrintInventory();
}