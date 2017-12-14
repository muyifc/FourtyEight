using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : Singleton<ResourcePool>
{
    private Dictionary<string, GameObject> pool = new Dictionary<string, GameObject>();
    public GameObject Spawn(string objName)
    {
        if (this.pool.ContainsKey(objName))
        {
            // pool[objName].SetActive(true);
            return pool[objName];
        }
        else
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(objName)) as GameObject;
			obj.name = objName;
            this.pool.Remove(objName);
            return obj;
        }
    }

    public void DeSpawn(string objName, GameObject obj)
    {
        obj.SetActive(false);
        if (this.pool.ContainsKey(objName))
            this.pool[objName] = obj;
        else
            this.pool.Add(objName, obj);
    }



}
