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

	// ��ũ�� ����Ʈ �ݺ��� ������ ������ �̿��� ��� ����Ű�� ���� �ٲ۴�.
	Node* current = &n1;
	while (current != nullptr)
	{
		cout << current->value << endl;
		current = current->next;
	}
}