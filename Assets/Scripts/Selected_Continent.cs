using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected_Continent : MonoBehaviour
{
    public string continent;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
}
