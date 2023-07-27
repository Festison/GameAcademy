#include <iostream>
#include <string>
#include <vector>
using namespace std;

struct Item
{
public:
	string name;
	int price;
	bool isUseable;

	Item()
	{

	}

	Item(string _name, int _price, bool _isUseable = false)
	{
		name = _name;
		price = _price;
		isUseable = _isUseable;
	}

	void PrintInfo()
	{
		cout << "이름 : " << name << endl;
		cout << "가격 : " << price << endl;
	}

	void UseItem()
	{
		if (isUseable)
		{
			cout << name << "을 사용했다" << endl;
		}
		else
		{
			cout << name << "은 사용할 수 없다." << endl;
		}
	}
};

struct ConsumptableItem : Item
{
	ConsumptableItem()
	{

	}

	void Use()
	{
		cout << name << "을 사용한다" << endl;
	}
};

struct EquipmentableItem : Item
{
	void Use()
	{
		cout << name << "을 장비한다" << endl;
	}
};

struct Inventory : Item
{
public:
	vector<Item*> inventory;

public:
	void PrintInventory()
	{
		cout << "--인벤토리 정보 출력--" << endl;
		for (int i = 0; i < inventory.size(); i++)
		{
			cout << i + 1 << "번째 아이템 정보" << endl;
			inventory.at(i)->PrintInfo();
		}
		cout << "--------------------" << endl;
	}

	void AddItem(Item* item)
	{
		Item* newItem = new Item;
		newItem->name = item->name;
		newItem->price = item->price;

		cout << "인벤토리에 (" << item->name << ") 아이템을 추가합니다.\n" << endl;
		inventory.push_back(newItem);
	}

	void DeleteItem(int index)
	{
		cout << "인벤토리에서 " << index << "번쨰 아이템을 삭제합니다.\n" << endl;

		inventory.erase(inventory.begin() + index);
	}

	void Use(int index)
	{
		inventory[index]->UseItem();

		if (inventory[index]->isUseable)
		{
			DeleteItem(index);
		}
	}
};

void main()
{
	Inventory inventory;

	// 상점
	Item sword("검", 100);
	Item potion("빨강포션", 10);

	inventory.AddItem(&sword);
	inventory.AddItem(&potion);

	inventory.PrintInventory();

	int input = 0;
	while (true)
	{
		cout << "사용할 아이템 번호를 선택하세요" << endl;
		cin >> input;
		inventory.Use(input - 1);
		inventory.PrintInventory();
	}

}
