using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectManager : MonoBehaviour {

    public enum ObjectType
    {
        Enemy,
        Player,
    }

    Dictionary<ObjectType, List<GameObject>> objectLists = new Dictionary<ObjectType, List<GameObject>>();

    public void AddObject(ObjectType objType, GameObject obj)       // 타입별로 그룹화해서, 오브젝트를 저장한다.
    {                                                               // 플레이어/몬스터등의 타입별로, 해당 객체를 추가
        if(objectLists.ContainsKey(objType))
        {
            objectLists[objType] = new List<GameObject>();
        }

        if(!objectLists[objType].Contains(obj))
        {
            objectLists[objType].Add(obj);
        }

    }

    public void RemoveObject(ObjectType objType, GameObject obj)        // 몬스터가 사라지거나 맵이 바뀌어서 객체가 바뀌는 경우
    {
        if(objectLists[objType].Contains(obj))
        {
            objectLists[objType].Remove(obj);
        }
    }

    public void Awake()
    {
       
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
