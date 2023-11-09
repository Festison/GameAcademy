using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 11월 08일 수요일자 학습 내용 : delegate, Lambda
public class Delegate : MonoBehaviour
{
    // delegate 대리자 
    // 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
    // C++에서의 함수 포인터와 같다.

    // delegate를 통해서 함수를 변수처럼 변경가능
    // delegate는 예외적으로 깊은 복사가 일어난다.
    public delegate void CustomFoo();
    public CustomFoo customFoo = null;

    // 매개변수도 없고 반환 타입도 없는 delegate 템플릿 : Action
    public Action action;
    // 매개변수와 반환 타입을 제네릭으로 정해주는 delegate 템플릿 : Func 
    // 마지막에 있는 bool은 반환값, 그 앞의 값들은 매개변수이다.
    public Func<int, bool> func;

    private void Start()
    {
        // 함수 대입
        customFoo = Foo;
        // 함수 호출
        customFoo();
    }

    public void Foo()
    {
        Debug.Log("함수 호출");
    }
}
