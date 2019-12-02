using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void onCollisionEnter(Collision other)
    {
        Debug.Log("aaa");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("AAA");
        }
    }
}
