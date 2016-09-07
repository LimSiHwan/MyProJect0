using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    static Dictionary<string, List<GameObject>> pool = new Dictionary<string, List<GameObject>>();
    
    public static int DotBlueCapacity = 0;
     
    public static void CreateObject(string key, GameObject parent)
    {
        List<GameObject> ObjList = new List<GameObject>();

        for (int i = 0; i < DotBlueCapacity; i++)
        {
            GameObject InstanceObj = Instantiate(Resources.Load(key)) as GameObject;
            InstanceObj.transform.parent = parent.transform;
            InstanceObj.SetActive(false);
            ObjList.Add(InstanceObj);
        }
        pool.Add(key, ObjList);
    }

    public static GameObject Instantiate(string key, Vector2 position, Quaternion rotation)
    {
        GameObject objs = null;

        foreach (var Object in pool[key])
        {
            if (!Object.activeSelf)
            {
                objs = Object;
                break;
            }
        }

        if(objs != null)
        {
            objs.SetActive(true);
            objs.transform.position = position;
            objs.transform.rotation = rotation;
        }
        else
        {
            //새로 추가작업..
        }

        return objs;
        
    }
}
