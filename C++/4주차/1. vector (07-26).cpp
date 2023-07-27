#include <iostream>
#include <vector>
using namespace std;

// STL
// vector : ���� �����迭
// �ٷ� �� ������ �Ҵ� �ȴ�.

int main()
{
	// vector(ũ��) ���� �Ҵ����� �迭�� ũ��
	vector <int> v(1000);
	v[0] = 0;
	v[1] = 1;
	v[2] = 2;
	v[3] = 3;
	v[4] = 4;
	
	v.begin(); // ������ ������ġ
	v.end();   // ������ ����ġ

	v.insert(v.begin(), 3); // ������ ������ġ�� 3 �߰�

	v.erase(v.begin());     // ������ ������ġ�� �ִ� ���Ҹ� ����

	// size�� ���� ������� ������ ũ��
	cout <<"������ ũ�� : "<< v.size() << endl;
	// capacity�� ���������� �Ҵ�� ������ ũ��
	cout <<"������ ���� ���� : "<< v.capacity() << endl;
	
	for (int i = 0; i < v.size(); i++)
	{
		cout <<i<<" ��° ������ ���ҿ� �ִ� ��: "<< v[i] << endl;
	}

	
}