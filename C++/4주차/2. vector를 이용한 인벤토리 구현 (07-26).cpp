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
		cout << "�̸� : " << name << endl;
		cout << "���� : " << price << endl;
	}

	void UseItem()
	{
		if (isUseable)
		{
			cout << name << "�� ����ߴ�" << endl;
		}
		else
		{
			cout << name << "�� ����� �� ����." << endl;
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
		cout << name << "�� ����Ѵ�" << endl;
	}
};

struct EquipmentableItem : Item
{
	void Use()
	{
		cout << name << "�� ����Ѵ�" << endl;
	}
};

struct Inventory : Item
{
public:
	vector<Item*> inventory;

public:
	void PrintInventory()
	{
		cout << "--�κ��丮 ���� ���--" << endl;
		for (int i = 0; i < inventory.size(); i++)
		{
			cout << i + 1 << "��° ������ ����" << endl;
			inventory.at(i)->PrintInfo();
		}
		cout << "--------------------" << endl;
	}

	void AddItem(Item* item)
	{
		Item* newItem = new Item;
		newItem->name = item->name;
		newItem->price = item->price;

		cout << "�κ��丮�� (" << item->name << ") �������� �߰��մϴ�.\n" << endl;
		inventory.push_back(newItem);
	}

	void DeleteItem(int index)
	{
		cout << "�κ��丮���� " << index << "���� �������� �����մϴ�.\n" << endl;

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

	// ����
	Item sword("��", 100);
	Item potion("��������", 10);

	inventory.AddItem(&sword);
	inventory.AddItem(&potion);

	inventory.PrintInventory();

	int input = 0;
	while (true)
	{
		cout << "����� ������ ��ȣ�� �����ϼ���" << endl;
		cin >> input;
		inventory.Use(input - 1);
		inventory.PrintInventory();
	}

}
