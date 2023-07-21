#include <iostream>
#include <synchapi.h>
using namespace std;

struct Item
{
	string name;
	int price;

	// 가상함수
	// 자식에서 재정의가 될것이라 예상되는 함수에 붙임
	Item(string _name, int _price)
	{
		name = _name;
		price = _price;
	}

	virtual void Use()
	{
		cout << "아이템 사용" << endl;
	}
};

struct ConsumableItem : Item
{
	bool isUse;

	// 일반 생성자를 이용한 생성자 오버로딩
	ConsumableItem(string _name, int _price, bool _isUse = false) : Item(_name, _price)
	{
		isUse = _isUse;
	}

	void Use()
	{
		cout << "아이템 소모 됨" << endl;
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
		cout << "장비 장착 됨" << endl;
	}
};

struct Character
{
	Character* InteractionTarget;
	string name;
	int hp;
	int atk;

	// 캐릭터끼리 공격을 할 것으로 예상됨으로 캐릭터의 포인터 변수를 넘겨준다.
	void Attack(Character* target)
	{
		InteractionTarget = target;
		target->InteractionTarget = this;

		cout << name << "이" << target->name << "을 공격합니다." << endl;

		target->TakeDamage(atk);
		cout << target->name << "의 현재 체력 : " << target->hp << endl;

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

	// 플레이어와 몬스터가 죽었을때 기능이 다르기 때문에 virtual을 사용한다.
	virtual void Die()
	{
		cout << name << "은 죽었다." << endl;
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
		cout << additionalExp << "만큼 경험치를 획득 했습니다." << endl;
	}
};

int main()
{

	Monster monA;
	monA.name = "스켈레톤";
	monA.hp = 30;
	monA.atk = 10;
	monA.additionalExp = 30;

	Monster monB;
	monB.name = "골든 스켈레톤";
	monB.hp = 100;
	monB.atk = 50;
	monB.additionalExp = 100;

	Player player;
	player.name = "용사A";
	player.level = 1;
	player.exp = 0;
	player.hp = 100;
	player.atk = 10;
}

