#include <iostream>
#include <vector>
using namespace std;

// STL
// vector : 동적 가변배열
// 바로 힙 영역에 할당 된다.

int main()
{
	// vector(크기) 최초 할당해줄 배열의 크기
	vector <int> v(1000);
	v[0] = 0;
	v[1] = 1;
	v[2] = 2;
	v[3] = 3;
	v[4] = 4;
	
	v.begin(); // 벡터의 시작위치
	v.end();   // 벡터의 끝위치

	v.insert(v.begin(), 3); // 벡터의 시작위치에 3 추가

	v.erase(v.begin());     // 벡터의 시작위치에 있는 원소를 삭제

	// size는 지금 사용중인 공간의 크기
	cout <<"벡터의 크기 : "<< v.size() << endl;
	// capacity는 실질적으로 할당된 공간의 크기
	cout <<"벡터의 여유 공간 : "<< v.capacity() << endl;
	
	for (int i = 0; i < v.size(); i++)
	{
		cout <<i<<" 번째 벡터의 원소에 있는 값: "<< v[i] << endl;
	}

	
}