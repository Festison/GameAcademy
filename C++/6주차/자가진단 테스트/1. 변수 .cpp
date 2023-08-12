#include<iostream>
using namespace std;

// 변수 사용
// 지역변수, 전역변수를 용도에 맞게 쓸 수 있다(주석으로 이유 서술)
// 설명 : 지역변수는 스택영역에 할당되어 지역을 나가면 반환됩니다. 전역변수는 데이터 영역에 할당되어 프로그램이 종료될때 반환됩니다.
// 동적 할당하여 변수를 사용할 수 있다.
// static 변수를 용도에 맞게 쓸 수 있다.
// 적합한 형 변환의 예를 쓸 수 있다.
// 업캐스팅, 다운캐스팅을 하여 사용할 수 있다. (업캐스팅 다운캐스팅의 설명은 주석으로 기입)
// 설명 : 업캐스팅이란 자식 클래스의 객체가 부모 클래스 타입으로 형변환 되는 것을 말합니다.
// 다운캐스팅이란 반대로 부모 클래스가 자식 클래스의 타입으로 형변환 되는 것을 말합니다.

class Counter
{
public:
    // 생성자
    Counter() 
    {
        count++;  // 객체가 생성될 때마다 count 증가
    }

    // 소멸자
    ~Counter() 
    {
        count--;  // 객체가 소멸될 때마다 count 감소
    }

    // static 멤버 함수
    static int GetCount()
    {
        return count;  // 생성된 객체의 수 반환
    }
    

private:
    static int count;  // 객체의 수를 저장하는 static 변수
};

class Shape
{
public:
    virtual void Draw()
    {
        cout << "도형을 그립니다." << endl;
    }
};

// 파생 클래스
class Circle : public Shape
{
public:
    void Draw() override 
    {
        cout << "원을 그립니다." <<endl;
    }

    void Circumference()
    {
        cout << "원의 둘레를 구합니다." << endl;
    }
};

// static 변수 초기화
int Counter::count = 0;

int globalcount = 0;

void GetLocalCount()
{
    int localcount = 0;
    localcount++;
}

void GetGlobalCount()
{
    globalcount++;
}

int main() 
{
    Counter c1; 
    Counter c2;  
    Counter c3;  

    cout << "생성된 객체의 수: " << Counter::GetCount() <<endl;
    GetLocalCount();
    GetGlobalCount();

    cout << globalcount;

    // 업캐스팅: 파생 클래스 객체를 기본 클래스 포인터로 가리키기
    Circle circle;
    Shape* shapePtr = &circle;

    // 다운캐스팅: 기본 클래스 포인터를 파생 클래스 포인터로 변환
    Circle* circlePtr = dynamic_cast<Circle*>(shapePtr);

    // 다운캐스팅한 객체를 사용하여 파생 클래스의 특화된 함수 호출
    if (circlePtr) 
    {
        circlePtr->Circumference();
    }
    else 
    {
        cout << "다운캐스팅 실패" << endl;
    }

    return 0;
}
