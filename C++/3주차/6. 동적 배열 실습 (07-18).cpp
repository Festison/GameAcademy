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
		cout << "이름 : " << type << endl;
	}

	virtual void Attack()
	{
		cout << "공격을 시작합니다." << endl;
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
		if (type == "총")
		{
			cout << "탕" << endl;
		}
	}
};

struct Sword : Weapon
{
	void Attack()
	{
		cout << "스릉~" << endl;
	}
};

int main()
{
	Inventory inven;
	Item item;
	Weapon weapon;
	Gun gun;
	Sword sword;

	inven.AddItem(item, item.name = "무기", item.toolTip = "검입니다.", item.price = 100);
	inven.PrintInventory();

	weapon.AddWeapon(inven, weapon.type = "검");
	weapon.PrintEquipmentuInfo();
	weapon.Attack();
	sword.Attack();
}