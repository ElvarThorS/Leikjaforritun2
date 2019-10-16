using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float Health = 10;
    public AnimationManager AM;
    
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) { Die(); }
    }



    void Die()
    {
        gameObject.SetActive(false);
    }
}
