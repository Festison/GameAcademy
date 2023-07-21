#include <iostream>
#include <synchapi.h>
using namespace std;

struct Item
{
	string name;
	int price;

	// �����Լ�
	// �ڽĿ��� �����ǰ� �ɰ��̶� ����Ǵ� �Լ��� ����
	Item(string _name, int _price)
	{
		name = _name;
		price = _price;
	}

	virtual void Use()
	{
		cout << "������ ���" << endl;
	}
};

struct ConsumableItem : Item
{
	bool isUse;

	// �Ϲ� �����ڸ� �̿��� ������ �����ε�
	ConsumableItem(string _name, int _price, bool _isUse = false) : Item(_name, _price)
	{
		isUse = _isUse;
	}

	void Use()
	{
		cout << "������ �Ҹ� ��" << endl;
	}
};

struct EquipmentableItem : Item
{
	int value;
	bool isEquip;

	EquipmentableItem(string _name, int _price, int _value, bool _isEquip = false) : Item(_name, _price)
	{
		value = _value;
		isEquip = isEquip;
	}

	void Use()
	{
		cout << "��� ���� ��" << endl;
	}
};

struct Character
{
	Character* InteractionTarget;
	string name;
	int hp;
	int atk;

	// ĳ���ͳ��� ������ �� ������ ��������� ĳ������ ������ ������ �Ѱ��ش�.
	void Attack(Character* target)
	{
		InteractionTarget = target;
		target->InteractionTarget = this;

		cout << name << "��" << target->name << "�� �����մϴ�." << endl;

		target->TakeDamage(atk);
		cout << target->name << "�� ���� ü�� : " << target->hp << endl;

	}
	void TakeDamage(int damage)
	{
		hp -= damage;

		if (hp <= 0)
		{
			hp = 0;
			Die();
		}
	}

	// �÷��̾�� ���Ͱ� �׾����� ����� �ٸ��� ������ virtual�� ����Ѵ�.
	virtual void Die()
	{
		cout << name << "�� �׾���." << endl;
	}

};

struct Player : Character
{
	int level;
	int exp;
};

struct Monster : Character
{
	int additionalExp;

	void Die()
	{
		Player* player = (Player*)InteractionTarget;
		Character::Die();
		player->exp += additionalExp;
		cout << additionalExp << "��ŭ ����ġ�� ȹ�� �߽��ϴ�." << endl;
	}
};

int main()
{

	Monster monA;
	monA.name = "���̷���";
	monA.hp = 30;
	monA.atk = 10;
	monA.additionalExp = 30;

	Monster monB;
	monB.name = "��� ���̷���";
	monB.hp = 100;
	monB.atk = 50;
	monB.additionalExp = 100;

	Player player;
	player.name = "���A";
	player.level = 1;
	player.exp = 0;
	player.hp = 100;
	player.atk = 10;
}

