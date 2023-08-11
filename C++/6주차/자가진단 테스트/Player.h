#pragma once
// 함수의 선언부와 구현부를 cpp파일과 헤더파일을 이용해 분리

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



