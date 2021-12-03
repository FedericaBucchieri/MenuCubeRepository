using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetechedSwitch : MonoBehaviour
{

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x:" + this.transform.rotation.x + " y:" + this.transform.rotation.y + " z:" + this.transform.rotation.z);
    }
}
