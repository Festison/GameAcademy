using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 객체의 복사 : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject firePointObj;
    GameObject copyObj;

    // 게임 오브젝트 bulletObj를 복사하려면
    // Instantiate(복사할 대상, 복사가될 위치, 회전값);
    
    // 불렛 오브젝트가 생성될 위치와 회전값을 지정
    // Istantiate는 리턴해서 돌아오는 것이 복사가 된 게임오브젝트이다.
    copyObj = Instantiate(bulletObj, firePointObj.transform.position, firePointObj.transform.rotation);
    // bulletObj를 firePointObj의 위치와 회전을 참고해 복사 생성해서 복사된 게임 오브젝트를 담았다.
    copyObj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    // 객체를 Prefab화 시켜서 원본이 없어져도 객체를 복사 할 수있다.
}
