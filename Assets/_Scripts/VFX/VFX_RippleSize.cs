using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_RippleSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = VolvoxSize.instance.transform.localScale;
    }
}
