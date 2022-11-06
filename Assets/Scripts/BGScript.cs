using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public static BGScript BgInstance; // instance of the music

    private void Awake()
    {
        if (BgInstance != null && BgInstance != this) // if there already exists an instance & isn't this one
        {
            Destroy(this.gameObject); // destroy this instance
            return;
        }
        BgInstance = this; // set this instance to the BG instance
        DontDestroyOnLoad(this); // don't destroy when load
    }

    
}
