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

struct Weapon
{
	Inventory* invenPtr;
	string type;

	void AddWeapon(Inventory inven, string type)
	{
		invenPtr = new Inventory;
		*invenPtr = inven;
		type = type;
	}

	void PrintEquipmentuInfo()
	{
		cout << "�̸� : " << type << endl;
	}

	virtual void Attack()
	{
		cout << "������ �����մϴ�." << endl;
	}
};

struct Armor
{

};

struct Player
{

};

struct Gun : Weapon
{
	void Attack()
	{
		if (type == "��")
		{
			cout << "��" << endl;
		}
	}
};

struct Sword : Weapon
{
	void Attack()
	{
		cout << "����~" << endl;
	}
};

int main()
{
	Inventory inven;
	Item item;
	Weapon weapon;
	Gun gun;
	Sword sword;

	inven.AddItem(item, item.name = "����", item.toolTip = "���Դϴ�.", item.price = 100);
	inven.PrintInventory();

	weapon.AddWeapon(inven, weapon.type = "��");
	weapon.PrintEquipmentuInfo();
	weapon.Attack();
	sword.Attack();
}