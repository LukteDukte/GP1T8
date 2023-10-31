using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBouncer : MonoBehaviour
{
    [Range(0f, 2f)] public float outsideRangeFactor = 1.1f;
    public float bounceForce = 10;

    private Rigidbody rb;
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = Volvox.Instance.rb;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.color = Color.white;
        Vector3 pos1 = ClampedScreenPosToWorld(0, 0);
        Vector3 pos2 = ClampedScreenPosToWorld(0, Screen.height);
        Vector3 pos3 = ClampedScreenPosToWorld(Screen.width, Screen.height);
        Vector3 pos4 = ClampedScreenPosToWorld(Screen.width, 0);
        Gizmos.DrawLine(pos1, pos2);
        Gizmos.DrawLine(pos2, pos3);
        Gizmos.DrawLine(pos3, pos4);
        Gizmos.DrawLine(pos4, pos1);

        Gizmos.color = Color.red;
        minX = (1f - outsideRangeFactor) / 2f * Screen.width;
        maxX = Screen.width - minX;
        minY = (1f - outsideRangeFactor) / 2f * Screen.height;
        maxY = Screen.height - minY;
        pos1 = ClampedScreenPosToWorld(minX, minY);
        pos2 = ClampedScreenPosToWorld(minX, maxY);
        pos3 = ClampedScreenPosToWorld(maxX, maxY);
        pos4 = ClampedScreenPosToWorld(maxX, minY);
        
        Gizmos.DrawLine(pos1, pos2);
        Gizmos.DrawLine(pos2, pos3);
        Gizmos.DrawLine(pos3, pos4);
        Gizmos.DrawLine(pos4, pos1);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        minX = (1f - outsideRangeFactor) / 2f * Screen.width;
        maxX = Screen.width - minX;
        minY = (1f - outsideRangeFactor) / 2f * Screen.height;
        maxY = Screen.height - minY;
        // print(Camera.main.WorldToScreenPoint(transform.position));
    }

    private void FixedUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < minX)
        {
            rb.AddForce(Vector3.right * bounceForce, ForceMode.Acceleration);
        }
        if (screenPos.x > maxX)
        {
            rb.AddForce(Vector3.left * bounceForce, ForceMode.Acceleration);
        }if (screenPos.y < minY)
        {
            rb.AddForce(Vector3.forward * bounceForce, ForceMode.Acceleration);
        }if (screenPos.y > maxY)
        {
            rb.AddForce(Vector3.back * bounceForce, ForceMode.Acceleration);
        }
        
    }

    Vector3 ClampedScreenPosToWorld(float x, float y)
    {
        float minX = (1f - outsideRangeFactor) / 2f * Screen.width;
        float maxX = Screen.width - minX;

        float minY = (1f - outsideRangeFactor) / 2f * Screen.height;
        float maxY = Screen.height - minY;

        float clampedX = Mathf.Clamp(x, minX, maxX);
        float clampedY = Mathf.Clamp(y, minY, maxY);

        Vector3 clampedWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(clampedX, clampedY,
            Camera.main.nearClipPlane));

        Vector3 clampedProjectedPos = GetProjectedPosion(clampedWorldPos);
        return clampedProjectedPos;
    }

    public Vector3 GetProjectedPosion(Vector3 worldPos)
    {
        Vector3 projectDir = (worldPos - Camera.main.transform.position).normalized;
        float d = Vector3.Dot(worldPos, Vector3.up) / Vector3.Dot(-projectDir, Vector3.up);
        Vector3 projectedPos = worldPos + projectDir * d;
        return projectedPos;
    }
}
