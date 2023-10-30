using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public GameObject lightBeam;
    public GameObject lightBulb;

    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        ShootLightTowardsTargetPosition(Volvox.Instance.transform.position);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        lightBulb.transform.position = GetProjectedPosion(transform.position);
        lightBeam.transform.position = GetProjectedPosion(transform.position);
    }

    public void Toggle()
    {
        if (isOn)
        {
            turnOffTheLight();
        }
        else
        {
            turnOnTheLight();
        }
    }

    public void turnOnTheLight()
    {
        if (isOn) return;

        isOn = true;
        lightBeam.SetActive(true);
    }

    public void turnOffTheLight()
    {
        if (!isOn) return;

        isOn = false;
        lightBeam.SetActive(false);
    }

    public void ShootLightTowardsTargetPosition(Vector3 targetPos)
    {
        if ((targetPos - lightBeam.transform.position).magnitude < 0.001f) return;
        lightBeam.transform.forward = targetPos - lightBeam.transform.position;
    }
    public Vector3 GetProjectedPosion(Vector3 ScreenPos)
    {
        Vector3 projectDir = (ScreenPos - Camera.main.transform.position).normalized;
        float d = Vector3.Dot(ScreenPos, Vector3.up) / Vector3.Dot(- projectDir, Vector3.up);
        Vector3 projectedPos = ScreenPos + projectDir * d;
        return projectedPos;
    }
}