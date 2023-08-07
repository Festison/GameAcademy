#include <iostream>
using namespace std;

class Player
{
private:
	int hp = 100;
	int atk = 10;
public:
	// 함수명 () 뒤에 const키워드가 뒤에 붙으면 멤버 변수들의 값을 이 함수내에선 변경할 수 없다는 뜻
	// Get, Set 함수 접근 할 수 없는 속성에 접근하기 위한 함수
	const int& GetHp() const
	{
		return hp;
	}

	int GetHp()
	{
		// hp는 Rvalue 임시값
		return hp;
	}

	void SetHp(int _hp)
	{
		hp = _hp;
	}
};

int main()
{
	int num = 10;
	int& nRef = num;

	//동일한 주소가 나오는것을 확인해보니
	//둘은 같은 놈을 말하는것을 알 수 있다.
	cout << &num << endl;
	cout << &nRef << endl;

	const int test = 10;
	nRef = 50;

	const int& nConstRef = test;
	// test = 30;
	// nConstRef = 60;

}