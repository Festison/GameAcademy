#include<iostream>
using namespace std;

struct Node
{
	Node* next = nullptr;
	int value;

	Node(int value)
	{
		this->value = value;
	}
};


int main()
{
	Node n1(10);
	Node n2(20);
	Node n3(30);

	n1.next = &n2;
	n2.next = &n3;

	// 링크드 리스트 반복문 포인터 변수를 이용해 계속 가리키는 곳을 바꾼다.
	Node* current = &n1;
	while (current != nullptr)
	{
		cout << current->value << endl;
		current = current->next;
	}
}