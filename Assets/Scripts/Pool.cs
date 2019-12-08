using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {

    public List<GameObject> list;
    public GameObject obj;
    public Transform pos;
    public int length = 50;

    void Start()
    {
        list = new List<GameObject>();
        for (int i = 0; i < length / 2; i++)
        {
            var o = Instantiate<GameObject>(obj, pos.position, Quaternion.identity);
            o.SetActive(false);
            list.Add(o);
        }
    }

    public void Spawn()
    {
        list[0].transform.position = pos.position;
        list[0].SetActive(true);
        list.RemoveAt(0);
    }

    public void BackToList(GameObject g)
    {
        g.SetActive(false);
        list.Add(g);
    }
}
