using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // boxcollider는 처음엔 아무것도 가리키고 있지 않았다.
    public BoxCollider boxCollider = null;
    public GameObject cube = null;
    public GameObject targetObjFindOfType = null;


    private void Start()
    {
        // GetComponent<BoxCollider>()를 통해 Test컴포넌트가 들어가 있는 게임오브젝트의 컴포넌트를 검색해서 boxcollider를 가져와 넣어 줬다.
        boxCollider = GetComponent<BoxCollider>();

        // 연산양이 많아지고 똑같은 이름의 게임 오브젝트가 있을 수 있어서 사용을 자제
        cube = GameObject.Find("Cube");

        // 박스 콜라이더를 가지고있는 게임오브젝트를 찾아온다.
        // 안에있는 컴포넌트를 하나하나 전부 확인한다.
        targetObjFindOfType = GameObject.FindObjectOfType<BoxCollider>().gameObject;

    }

    private void Update()
    {
        // boxCollider를 통해서 게임오브젝트를 가져올 수 있다.
        Destroy(boxCollider.gameObject);
    }





}
