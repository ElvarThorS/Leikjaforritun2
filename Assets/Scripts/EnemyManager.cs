using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public float Health = 10;
    public bool GotHit = false; 

    // Start is called before the first frame update
    void Start()
    {
        GotHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GotHit == true)
        {
            GotHit = false;
            Health -= 1;
        }

        if(Health <= 0) { Die(); }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
