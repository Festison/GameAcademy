#pragma once
// �Լ��� ����ο� �����θ� cpp���ϰ� ��������� �̿��� �и�

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



