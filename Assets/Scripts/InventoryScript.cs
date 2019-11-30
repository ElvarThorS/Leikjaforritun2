<<<<<<< HEAD
﻿using System.Collections;
=======
﻿using System;
using System.Collections;
>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======

    private const int Slots = 9;
    private List<InventoryItem> mItems = new List<InventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(InventoryItem item)
    {
        if(Slots > mItems.Count)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);
                item.OnPickUp();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

>>>>>>> bb7521c4f21294206e67d3209d119b2d3d1fc728
}
