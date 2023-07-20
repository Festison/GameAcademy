#include <iostream>

using namespace std;

struct Item
{
	string name;
	string toolTip;
	int price;

	void PrintInfo()
	{
		cout << "�̸� : " << name << endl;
		cout << "���� : " << toolTip << endl;
		cout << "���� : " << price << endl;
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
			cout << i << "��° ������ ����" << endl;
			itemPtr[i]->PrintInfo();
		}
	}

	void AddItem(Item item, string name, string toolTip, int price)
	{
		if (count >= 10)
		{
			count = 9;
			cout << "�κ��丮�� ��á���ϴ�" << endl;
			return;
		}

		itemPtr[count] = new Item;
		*itemPtr[count] = item;
		count++;
	}

	~Inventory() //~����ü��()   �Ҹ���
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


	inven.AddItem(item1, item1.name = "����", item1.toolTip = "�����Դϴ�.", item1.price = 100);

	inven.PrintInventory();
}