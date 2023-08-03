#include<iostream>
#include<vector>

using namespace std;

struct Item
{
	string name;
	int price;

	Item();
	Item(string _name, int _price);
	void PrintInfo();
	virtual void Use();
	virtual Item* Clone();
};

struct ConsumptableItem : Item
{
	int effectValue;

	ConsumptableItem(string _name, int _price, int effectValue);
	void Use();
	Item* Clone();
};

struct EquipmentableItem : Item
{
	EquipmentableItem();
	EquipmentableItem(string _name, int _price);
	void Use();
	Item* Clone();
};

struct Weapon : EquipmentableItem
{
	bool isEquip;

	Weapon(string _name, int _price);
	virtual void AttackSupport();
	void Use();
	Item* Clone();
};

struct Inventory
{
	vector<Item*> inven;

	void PrintInventory();
	void Use(int index);
	void AddItem(Item* item);
	void DeleteItem(int index);
};

struct Player
{
	Inventory inven;
	Weapon* weapon;
	string name;
	int gold;

	void Attack();
};

struct Store
{
	vector<Item*> items;
	Player* customer;

	void InStore();
	void PrintItem(int index);
	void Close();
};

void main()
{

}


Item::Item()
{

}
Item::Item(string _name, int _price)
{
	name = _name;
	price = _price;
}
void Item::PrintInfo()
{
	cout << "이름 : " << name << endl;
	cout << "가격 : " << price << endl;
}
void Item::Use()
{
	cout << name << "을(를) 사용" << endl;
}
Item* Item::Clone()
{
	return new Item(*this);
}

ConsumptableItem::ConsumptableItem(string _name, int _price, int effectValue)
{
	name = _name;
	price = _price;
	effectValue = effectValue;
}
void ConsumptableItem::Use()
{
	cout << name << "을 소모한다" << endl;
}
Item* ConsumptableItem::Clone()
{
	return new ConsumptableItem(*this);
}

EquipmentableItem::EquipmentableItem(string _name, int _price)
{
	name = _name;
	price = _price;
}
void EquipmentableItem::Use()
{
	cout << name << "을 장착한다" << endl;
}
Item* EquipmentableItem::Clone()
{
	return new EquipmentableItem(*this);
}

Weapon::Weapon(string _name, int _price)
{
	name = _name;
	price = _price;
}
void Weapon::AttackSupport()
{
	cout << name << "으로 공격한다" << endl;
}
void Weapon::Use()
{
	cout << name << "을 무기칸에 장착한다" << endl;
}
Item* Weapon::Clone()
{
	return new Weapon(*this);
}

void Inventory::PrintInventory()
{

}
void Inventory::Use(int index)
{

}
void Inventory::AddItem(Item* item)
{

}
void Inventory::DeleteItem(int index)
{

}

void Player::Attack()
{

}

void Store::InStore()
{

}
void Store::PrintItem(int index)
{

}
void Store::Close()
{

}