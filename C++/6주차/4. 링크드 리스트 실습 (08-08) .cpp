#include<iostream>
#include<list>
using namespace std;

class Node
{
public:
	Node(int value)
	{
		this->value = value;
	}

public:
	Node* next = nullptr;
	Node* prev = nullptr;
	int value;

};

class LinkedList
{
private:
	Node* start = nullptr;
	Node* end = nullptr;
	int size = 0;

public:
	bool IsEmpty()
	{
		return (size <= 0);
	}
	//맨 뒤에 넣음.
	void PushBack(int value)
	{
		Node* newNode = new Node(value);

		if (IsEmpty())
		{
			start = newNode;
			end = newNode;
		}
		else
		{
			end->next = newNode;
			end = newNode;
		}
		cout << newNode->value << endl;
		size++;
	}
	//정해진 위치에 넣음
	void Insert(int index, int value)
	{
		Node* newNode = new Node(value);
		Node* current = start;

		if (IsEmpty())
		{
			start = newNode;
			end = newNode;
		}
		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}
		current->value = value;
		cout << current->value << endl;
		size++;
	}
	//정해진 위치에 있는것을 지움
	void Delete(int index)
	{
		Node* current = start;

		if (IsEmpty())
		{
			cout << "리스트가 비어 있어서 삭제할 데이터가 없습니다." << endl;
		}
		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}

		delete current;
		size--;
	}
	//정해진 위치의 값을 가져옴
	int At(int index)
	{
		Node* current = start;

		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}

		return current->value;
	}
	//값이 있는지 체크함.
	bool Search(int value)
	{
		Node* current = start;

		while (current->value != value)
		{
			current = current->next;			
		}
		if (current->value == value)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
};

int main()
{
	LinkedList lList;

	lList.PushBack(10);
	lList.PushBack(20);
	lList.PushBack(30);

	lList.Insert(2, 50);
	cout << lList.At(2) << endl;

	lList.Delete(2);	

	if (lList.Search(50))
	{
		cout << "50이 있다" << endl;
	}
}