#include "Player.h"
#include <iostream>
using namespace std;

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
	cout << "��簡 �Ҹ�Ǿ����ϴ�." << endl;
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



