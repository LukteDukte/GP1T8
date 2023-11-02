using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDust : MonoBehaviour
{
    public ParticleSystem dustParticle;

    [SerializeField] private float baseSize = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mainModule = dustParticle.main;
        mainModule.startSize = baseSize + (LoadThisAddedtiveScene.Instance.currentLevel - 1) * 0.02f;
    }
}
