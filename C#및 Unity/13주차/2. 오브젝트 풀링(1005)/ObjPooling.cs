using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 오브젝트 풀링 : 빈번한 생성과 파괴는 연산적으로 비 효율적이다.
// 따라서 자주 사용하는 오브젝트를 미리 생성해 놓고 이걸 사용할 때마다 새로 생성 삭제 하는 것이 아닌 미리 만들어둘 객체들을 담아둘 콜렉션(풀)을 만들어둔다.
// 사용할 때는 오브젝트 풀한테 빌려서 사용하고 삭제할 때는 오브젝트풀한테 돌려줌으로써 단순하게 오브젝트를 활성화 비활성화만 하는 개념이다.

public class ObjPooling : MonoBehaviour
{
    // 오브젝트 풀링 순서
    // 1. 미리 만들어둔 게임오브젝트를 담아둘 콜렉션(풀)을 만든다.
    // 2. 비활성화 상태로 생성해서 콜렉션(풀)에 담아둔다.
    // 3. 사용할 때 활성화 한다.
    // 4. 다 사용시 비활성화 상태로 콜렉션(풀)에 다시 담아둔다.

    public static ObjPooling instance = null;    // static이 달리면 클래스 자체가 가지는 스태틱 변수이다.
    public Queue<GameObject> pool;               // 오브젝트 풀을 관리할 큐
    public GameObject prefab;                    // 오브젝트풀에서 관리할 오브젝트
    public int initSize;                         // 미리 생성해둘 오브젝트의 개수   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pool = new Queue<GameObject>();

        Init();
    }

    // 최초의 오브젝트 풀링을 초기화 할 함수
    public void Init()
    {
        AddPool(initSize);
    }

    // 나중에 만들어서 비활성화하고 넣어주는 함수
    public void AddPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject temp = null;         // GameObject temp를 만들어서 null을 가리킨다.
            temp = Instantiate(prefab);     // Instantiate를 통해서 prefab의 사본 게임오브젝트를 만들고
                                            // temp가 새로 만들어진 그놈의 주소를 가리키도록한다.
            temp.SetActive(false);          // temp가 새로 만들어진 놈을 가리키고있으므로 SetActive(false)는
                                            // 새로 만들어진 오브젝트를 비활성화 한다.
            pool.Enqueue(temp);             // 새로 만들어지고 비활성화 된 게임오브제그의 주소를 큐에 담는다.
        }
    }

    // 큐에 있는 게임오브젝트의 위치와 회전을 가져와 활성화 시키는 함수
    public void PopObj(Vector3 pos, Quaternion rot)
    {
        // 큐에 들어있는 게임오브젝트의 개수가 0 이하일시 추가로 넣어 준다.
        if (pool.Count <= 0)
        {
            AddPool(initSize / 2);
        }

        GameObject dequeObj = pool.Dequeue();
        dequeObj.transform.position = pos;
        dequeObj.transform.rotation = rot;
        dequeObj.SetActive(true);
    }

    // 다 쓴 게임오브젝트를 비활성화 시켜 풀에 넣어준다.
    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }
}
