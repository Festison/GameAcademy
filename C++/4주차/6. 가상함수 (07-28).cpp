#include <iostream>
#include <vector>
using namespace std;

// 요구사항 //
// 플레잉어는 무기를 가질 수 있음//
// 무기는 각각 다르게 작용할 수 있음//

struct Weapon
{
public:
	bool isUseable = true;
	int incraseDamage;

	// 가상 함수는 상속하는 클래스 내에서 같은 시그니처의 함수로 오버라이딩 될 수 있는 함수 또는 메소드이다. 
	// 이 개념은 객체 지향 프로그래밍 (OOP)의 다형성에서 중요한 부분이다.
	// 정의되지 않은 가상함수는 순수 가상함수라고한다.
	// 순수 가상함수가 하나이상 포함되었다면,
	// 자식에서 꼭 정의해줘야한다.
	// 그런 구조체 혹은 클래스를 추상클래스라고한다.
public:
	virtual void Attack() = 0;
};
		
struct Gun : Weapon
{
public:
	int bulletCount = 5;

public:
	void Attack() override
	{
		if (bulletCount > 0)
		{
			bulletCount--;

			cout << "탕" << endl;
		}
		else
		{
			cout << "철컥철컥 !" << endl;
			isUseable = false;
		}
	}


};

struct Sword : Weapon
{
	int randNum = 1;

	void Attack() override
	{
		for (int i = 0; i < randNum; i++)
		{
			cout << "서-겅" << endl;
		}
	}
};

// const는 변수를 상수화 시켜주는 키워드
// 상수화 된 변수는 값을 변경 할 수 없다.
const int Max_WEAPON_INDEX = 5;

struct Player
{
	// has - a 관계
	// 쓰레기값을 가리키고 있기 때문에 nullptr을 가리키게 초기화;
private:
	Weapon* weapon[Max_WEAPON_INDEX]; 
	int curWeaponIndex = 0;

public:
	// 생성자를 이용한 weapon초기화
	Player()
	{
		for (int i = 0; i < Max_WEAPON_INDEX; i++)
		{
			weapon[i] = nullptr;
		}
	}

	void Attack()
	{
		if (weapon[curWeaponIndex] != nullptr)
		{
			if (weapon[curWeaponIndex]->isUseable)
			{
				weapon[curWeaponIndex]->Attack();
			}
			else
			{
				SetWeapon(nullptr);
			}
		}
		else
		{
			cout << "펀치!" << endl;
		}
	}

	void SetWeapon(Weapon* _weapon, int index)
	{
		if (weapon[index] != nullptr)
		{
			delete weapon[index];
		}

		weapon[index] = _weapon;
	}

	void SetWeapon(Weapon* _weapon)
	{
		SetWeapon(_weapon, curWeaponIndex);
	}

	void SetCurWeaponIndex(int value)
	{
		if (value >= Max_WEAPON_INDEX)
		{
			cout << Max_WEAPON_INDEX << "이상으로 클 수 없습니다. 0으로 셋팅" << endl;
			value = 0;
		}
		curWeaponIndex = value;
	}
};

int main()
{
	vector <Weapon*> weapons;
	weapons.push_back(new Gun);

	Player player;

	// 순수가상 함수로 만든 객체는 새로운 객체를 만들어 줄 수가 없다.
	// player.weapon = new Weapon;

	player.SetWeapon(new Sword, 1);
	player.SetWeapon(new Gun, 2);

	int input = 0;
	while (true)
	{
		cout << "무기를 선택하세요 0~" << Max_WEAPON_INDEX << endl;
		cin >> input;
		player.SetCurWeaponIndex(input);
		player.Attack();
	}
}