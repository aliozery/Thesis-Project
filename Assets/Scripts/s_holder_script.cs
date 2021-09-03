using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_holder_script : MonoBehaviour
{
    public void ClearChildren()
    {
        Transform transform;
            for(int i = 0;i < gameObject.transform.childCount; i++)
            {
                transform = gameObject.transform.GetChild(i);
                GameObject.Destroy(transform.gameObject);
            }

    }
}
