#include <iostream>
using namespace std;

// Stack
// 접시쌓기 맨마지막에 들어온놈이 먼저 처리되는 것
// 후입선출 - LIFO

struct Node
{
	Node* next = nullptr;
	Node* prev = nullptr;
	int value;

	Node(int value)
	{
		this->value = value;
	}
};

class Stack
{
private:
	Node* start = nullptr;
	Node* end = nullptr;
	int size = 0;
public:

	bool IsEmpty()
	{
		return (bool)(size <= 0);
	}

	void Push(int _value)
	{
		Node* newNode = new Node(_value);
		if (IsEmpty())
		{
			start = newNode;
			end = newNode;
		}
		else
		{
			newNode->prev = end;
			end = newNode;
		}

		size++;
	}

	int Pop()
	{
		int result = -1;

		if (IsEmpty())
		{
			cout << "비어있습니다" << endl;
			return result;
		}

		Node* temp = end;
		result = end->value;
		end = end->prev;
		delete temp;
		size--;
		return result;
	}
	const int& GetSize() const
	{
		return size;
	}
};


void main()
{
	Stack stack;
	stack.Push(10);
	stack.Push(20);
	stack.Push(30);

	cout << stack.Pop() << endl;
	cout << stack.Pop() << endl;
	cout << stack.Pop() << endl;
}