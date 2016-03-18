using UnityEngine;
using System.Collections.Generic;

public class RandomSteps : MonoBehaviour
{
  
    float AmendmentTo_z;
 
    Timer t;
    // Use this for initialization
    void Start()
    { 

        t = Timer.AddTimer(this.gameObject);
        t.interval = 0.4f;
        t.Elapsed += T_Elapsed;
        t.startTimer(); 
    }

 
    private void T_Elapsed()
    {
        AmendmentTo_z = Random.Range(-2f, 2f);
       
        t.startTimer(); 
    }


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector2(AmendmentTo_z, 1) * Time.deltaTime * 3); 
    }

 
}


