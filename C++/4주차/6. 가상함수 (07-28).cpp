#include <iostream>
#include <vector>
using namespace std;

// �䱸���� //
// �÷��׾�� ���⸦ ���� �� ����//
// ����� ���� �ٸ��� �ۿ��� �� ����//

struct Weapon
{
public:
	bool isUseable = true;
	int incraseDamage;

	// ���� �Լ��� ����ϴ� Ŭ���� ������ ���� �ñ״�ó�� �Լ��� �������̵� �� �� �ִ� �Լ� �Ǵ� �޼ҵ��̴�. 
	// �� ������ ��ü ���� ���α׷��� (OOP)�� ���������� �߿��� �κ��̴�.
	// ���ǵ��� ���� �����Լ��� ���� �����Լ�����Ѵ�.
	// ���� �����Լ��� �ϳ��̻� ���ԵǾ��ٸ�,
	// �ڽĿ��� �� ����������Ѵ�.
	// �׷� ����ü Ȥ�� Ŭ������ �߻�Ŭ��������Ѵ�.
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

			cout << "��" << endl;
		}
		else
		{
			cout << "ö��ö�� !" << endl;
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
			cout << "��-��" << endl;
		}
	}
};

// const�� ������ ���ȭ �����ִ� Ű����
// ���ȭ �� ������ ���� ���� �� �� ����.
const int Max_WEAPON_INDEX = 5;

struct Player
{
	// has - a ����
	// �����Ⱚ�� ����Ű�� �ֱ� ������ nullptr�� ����Ű�� �ʱ�ȭ;
private:
	Weapon* weapon[Max_WEAPON_INDEX]; 
	int curWeaponIndex = 0;

public:
	// �����ڸ� �̿��� weapon�ʱ�ȭ
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
			cout << "��ġ!" << endl;
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
			cout << Max_WEAPON_INDEX << "�̻����� Ŭ �� �����ϴ�. 0���� ����" << endl;
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

	// �������� �Լ��� ���� ��ü�� ���ο� ��ü�� ����� �� ���� ����.
	// player.weapon = new Weapon;

	player.SetWeapon(new Sword, 1);
	player.SetWeapon(new Gun, 2);

	int input = 0;
	while (true)
	{
		cout << "���⸦ �����ϼ��� 0~" << Max_WEAPON_INDEX << endl;
		cin >> input;
		player.SetCurWeaponIndex(input);
		player.Attack();
	}
}