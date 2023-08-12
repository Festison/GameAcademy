#include <iostream>
using namespace std;

// �Լ�, �迭, �����Ϳ� ������, ����ü�� Ŭ����, ��� ���
// �Ű������� ����Ÿ���� ���� �Լ��� �����ϰ� ������ �� �ִ�.
// �Լ��� ����ο� �����θ� �и��� �� �ִ�.
// �Լ��� �����ε� �� �� �ִ�.
// �Լ��� �������̵� �� �� �ִ�.
// �θ� ����Ͽ� �ڽ� ����ü�� Ŭ������ ���� �� �ִ�.
// �����Լ��� �����ϰ� ������ �� �ִ�. (�����Լ��� �������� �ּ����� ����) 
// ���� : �����Լ��� virtual Ű���带 �̿��� �θ𿡼��� �����ϰ� �ڽĿ��� �� ������ �������̵��ϴ� ����Դϴ�.
// �θ����¿��� �ڽĿ� ������ �� �����Լ��� ȣ���� �� �ִ�.
// �뵵�� �µ��� ����ü�� �����ϰ� �����Ͻÿ�. (����ü�� �������� �ּ����� ����)
// ���� : ����ü�� �迭�� �ٸ��� �ٸ� ������ Ÿ���� �����͸� �ϳ��� ���� ����Դϴ�.
// �뵵�� �µ��� Ŭ������ �����ϰ� �����Ͻÿ�. (Ŭ������ �������� �ּ����� ����)
// ���� : Ŭ������ ��ü�� �����ϴ� Ʋ ���赵 �Դϴ�. �Ӽ��� ����� ���� ��ü�� Ư¡�� ��Ÿ���ϴ�.
// ���������ڸ� �뵵�� �°� ����� �� �ִ�. (Ŭ������ ��� ��������ڱ���)
// ����ü�� Ŭ������ ����ο� �����θ� �и��� �� �ִ�.
// ����ü�� Ŭ������ �迭�� ���ҷ� ����� �� �ִ�.
// ����ü�� Ŭ������ �Լ��� ���ڷμ� ����� �� �ִ�.

#define KNIGHT_MIN_COUNT 1

class Player
{
public:
	Player();
	Player(int hp);
	virtual ~Player();
	virtual void PrintInfo();

public:
	int hp;
	int attack;
};

class Knight : public Player
{
public:
	Knight();
	Knight(int hp);
	~Knight() override;

	void PrintInfo() override;

public:
};

const int KNIGHT_COUNT = 10;

int main()
{
	Knight* knights[KNIGHT_COUNT];

	for (int i = 0; i < KNIGHT_COUNT; i++)
	{
		if (i % 2 == 0)
		{
			knights[i] = new Knight();
		}
		else
		{
			knights[i] = new Knight(200);
		}
	}

	for (int i = 0; i < KNIGHT_COUNT; i++)
	{
		knights[i]->PrintInfo();
		delete knights[i];
	}


}

Knight::Knight()
{
	this->hp = 100;
	this->attack = 10;
}

Knight::Knight(int hp)
{
	this->hp = hp;
	this->attack = 10;
}

Knight::~Knight()
{
	cout << "����Ʈ�� �Ҹ�Ǿ����ϴ�." << endl;
}

void Knight::PrintInfo()
{
	cout << "------knightInfo-----------" << endl;
	cout << "HP: " << hp << endl;
	cout << "ATT: " << attack << endl;
}


Player::Player()
{

}


Player::Player(int hp)
{

}

Player::~Player()
{

}

void Player::PrintInfo()
{
	cout << "------ PlayerInfo ------" << endl;
	cout << "HP: " << hp << endl;
	cout << "ATT: " << attack << endl;
}