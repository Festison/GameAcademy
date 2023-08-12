#include <iostream>
using namespace std;

// 함수, 배열, 포인터와 참조자, 구조체와 클래스, 상속 사용
// 매개변수와 리턴타입을 정해 함수를 선언하고 정의할 수 있다.
// 함수의 선언부와 구현부를 분리할 수 있다.
// 함수를 오버로딩 할 수 있다.
// 함수를 오버라이딩 할 수 있다.
// 부모를 상속하여 자식 구조체나 클래스를 만들 수 있다.
// 가상함수를 선언하고 정의할 수 있다. (가상함수가 무엇인지 주석으로 기입) 
// 설명 : 가상함수란 virtual 키워드를 이용해 부모에서는 선언만하고 자식에서 재 정의해 오버라이딩하는 기술입니다.
// 부모형태에서 자식에 재정의 된 가상함수를 호출할 수 있다.
// 용도에 맞도록 구조체를 선언하고 정의하시오. (구조체가 무엇인지 주석으로 기입)
// 설명 : 구조체란 배열과 다르게 다른 데이터 타입의 데이터를 하나로 묶는 방법입니다.
// 용도에 맞도록 클래스를 선언하고 정의하시오. (클래스가 무엇인지 주석으로 기입)
// 설명 : 클래스란 객체를 정의하는 틀 설계도 입니다. 속성과 기능을 통해 객체의 특징을 나타냅니다.
// 접근제한자를 용도에 맞게 사용할 수 있다. (클래스의 경우 상속제한자까지)
// 구조체나 클래스의 선언부와 구현부를 분리할 수 있다.
// 구조체나 클래스를 배열의 원소로 사용할 수 있다.
// 구조체나 클래스를 함수의 인자로서 사용할 수 있다.

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
	cout << "나이트가 소멸되었습니다." << endl;
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