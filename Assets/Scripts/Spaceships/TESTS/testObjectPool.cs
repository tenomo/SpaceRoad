using UnityEngine;
using System.Collections;
using Spaceships;
using Spaceships.ObjectPool;

public class testObjectPool : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.A))
        {
         GameObject go =    this.gameObject.GetComponent<PoolManager>().RoketPool.GetGameObject();
            Debug.Log(go.name);
        }
    }
}
