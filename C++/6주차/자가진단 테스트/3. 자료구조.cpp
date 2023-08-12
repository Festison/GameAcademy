#include <iostream>
using namespace std;

// 템플릿, 자료구조, 예외처리 사용
// 함수를 템플릿화 할 수 있다. (템플릿이 무엇인지 주석으로 기입) 
// 템플릿이란 함수나 클래스를 개별적으로 다시 작성하지 않아도, 여러 자료 형으로 사용할 수 있도록 하게 만들어 놓은 틀입니다.
// 구조체나 클래스를 템플릿화하고 사용할 수 있다.
// if문만을 사용하여 기본적인 예외처리를 할 수 있다.
// try throw catch문을 사용하여 위의 예외처리를 변경할 수 있다.
// 노드 구조체를 직접 만들 수 있다.
// 노드를 단방향이 아닌 양방향으로 만들 수 있다
// 노드 구조체를 사용하여 노드를 연결한 큐를 만들 수 있다.
// 노드 구조체를 사용하여 노드를 연결한 스택을 만들 수 있다.
// 노드 구조체를 사용하여 노드를 연결한 링크드리스트를 만들 수 있다.

template <typename T>
class Node
{
public:
	Node(T value)
	{
		this->value = value;
	}

public:
	Node* next = nullptr;
	Node* prev = nullptr;
	T value;

};

template <typename T>
class Stack
{
public:
	bool Empty()
	{
		return (size <= 0);
	}

	void Push(T value)
	{
		Node<int>* newNode = new Node<T>(value);

		if (Empty())
		{
			start = newNode;
			end = newNode;
		}
		else
		{
			end->next = newNode;
			newNode->prev = end;
			end = newNode;
		}
		size++;
	}

	T Pop()
	{
		T result = -1;

		Node<int>* temp = end;
		result = end->value;
		end = end->prev;

		delete temp;
		size--;
		return result;
	}

	const T& GetSize() const
	{
		return size;
	}

private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
};

class Queue
{
private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	int size = 0;
	int Pop()
	{
		int result = -1;
		if (IsEmpty())
			throw 0;

		Node<int>* temp = start;
		result = start->value;
		start = start->next;

		delete temp;

		size--;
		return result;
	}

public:

	bool IsEmpty()
	{
		return (bool)(size <= 0);
	}
	//뒤에 넣는거
	void Push(int _value)
	{
		Node<int>* newNode = new Node<int>(_value);
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

		size++;
	}

	bool Pop(int& input)
	{
		try
		{
			input = Pop();
		}
		catch (...)
		{
			cout << "비어져있습니다." << endl;
			return false;
		}
		return true;
	}


	const int& GetSize() const
	{
		return size;
	}
};

template <typename T>
class LinkedList
{
public:
	bool Empty()
	{
		return (size <= 0);
	}

	void Push(T value)
	{
		Node<int>* newNode = new Node<T>(value);

		if (Empty())
		{
			start = newNode;
			end = newNode;
		}
		else
		{
			end->next = newNode;
			newNode->prev = end;
			end = newNode;
		}
		size++;
		cout << newNode->value << endl;
	}

	void Insert(T index, const T& value)
	{
		Node<int>* newNode = new Node<T>(value);
		Node<int>* current = start;

		if (index > size)
		{
			cout << "인덱스가 사이즈보다 큽니다." << endl;
		}

		// 리스트의 첫 부분에 삽입
		if (index == 0)
		{			
			newNode->next = start;

			if (start != nullptr)
			{
				start->prev = newNode;
			}

			start = newNode;

			// 리스트가 비어있는 경우
			if (end == nullptr)
			{			
				end = newNode;
			}
		}

		// 리스트의 끝 부분에 삽입
		else if (index == size)
		{		
			end->next = newNode;
			newNode->prev = end;
			end = newNode;
		}
		// 중간에 삽입
		else
		{			
			for (size_t i = 0; i < index; i++)
			{
				current = current->next;
			}

			newNode->prev = current->prev;
			newNode->next = current;
			current->prev->next = newNode;
			current->prev = newNode;
		}

		size++;
	}

	void Delete(T index)
	{
		if (index < 0 || index >= size)
		{
			cout << "인덱스가 리스트의 크기보다 크거나 작아 리스트를 삭제할 수 없습니다." << endl;
		}
		else
		{
			Node<T>* current = start;
			for (int i = 0; i < index; i++)
			{
				current = current->next;
			}
			current->prev->next = current->next;
			current->next->prev = current->prev;
			delete current;
		}
		size--;
	}

	T At(T index)
	{
		if (index < 0 || index > size)
		{
			cout << "인덱스가 리스트의 크기보다 크거나 작아 리스트의 값에 접근할 수 없습니다." << endl;
		}

		Node<T>* current = start;

		for (int i = 0; i < index; i++)
		{
			current = current->next;
		}

		return current->value;
	}

	bool Search(T value)
	{
		Node<T>* current = start;

		while (current != nullptr)
		{
			if (current->value == value)
			{
				return true;
			}
			current = current->next;
		}
		return false;
	}

private:
	Node<int>* start = nullptr;
	Node<int>* end = nullptr;
	T size = 0;
};

int main()
{
	Stack<int> stack;
	Queue queue;
	LinkedList<int> lList;

	lList.Push(10);
	lList.Push(20);
	lList.Push(30);

	lList.Insert(0, 50);
	lList.Delete(2);

	cout << lList.At(2) << endl;

	if (lList.Search(50))
	{
		cout << "50이 있다" << endl;
	}

}