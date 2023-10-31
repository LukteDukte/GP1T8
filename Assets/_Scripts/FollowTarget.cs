using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public static FollowTarget Instance;
    // Start is called before the first frame update

    public float speedFactor = 0.1f;
    [Range(0.0f, 1.0f)] public float movingRangeFactor = 0.9f;
    private PlayerManager _playerManager;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 pos1 = ClampedScreenPosToWorld(0, 0);
        Vector3 pos2 = ClampedScreenPosToWorld(0, Screen.height);
        Vector3 pos3 = ClampedScreenPosToWorld(Screen.width, Screen.height);
        Vector3 pos4 = ClampedScreenPosToWorld(Screen.width, 0);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos1, pos2);
        Gizmos.DrawLine(pos2, pos3);
        Gizmos.DrawLine(pos3, pos4);
        Gizmos.DrawLine(pos4, pos1);
    }

    void Start()
    {
        _playerManager = PlayerManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerManager.lightSourceLeft.isOn && _playerManager.lightSourceRight.isOn)
        {
            Vector3 leftLightProjectedPos = GetClampedLightSourceProjectedPosion(_playerManager.lightSourceLeft);
            Vector3 rightLightProjectedPos = GetClampedLightSourceProjectedPosion(_playerManager.lightSourceRight);
            Vector3 dirBetweenLight = (rightLightProjectedPos - leftLightProjectedPos).normalized;
            Vector3 nearestPoint =
                Vector3.Dot(transform.position - leftLightProjectedPos, dirBetweenLight) * dirBetweenLight +
                leftLightProjectedPos;

            transform.position = Vector3.Lerp(transform.position, nearestPoint, speedFactor * Time.deltaTime);
        }
        else if (_playerManager.lightSourceLeft.isOn || _playerManager.lightSourceRight.isOn)
        {
            LightSource light = _playerManager.lightSourceLeft.isOn
                ? _playerManager.lightSourceLeft
                : _playerManager.lightSourceRight;
            Vector3 lightSorcePos = GetClampedLightSourceProjectedPosion(light);
            transform.position = Vector3.Lerp(transform.position,
                lightSorcePos, speedFactor * Time.deltaTime);
        }
        else
        {
        }
    }

    public Vector3 GetLightSourceProjectedPosion(LightSource lightSource)
    {
        Vector3 lightSourcePos = lightSource.transform.position;
        Vector3 lightSourceProjectDir = (lightSourcePos - Camera.main.transform.position).normalized;
        float d = Vector3.Dot(lightSourcePos, Vector3.up) / Vector3.Dot(-lightSourceProjectDir, Vector3.up);
        Vector3 lightSourceProjectedPos = lightSourcePos + lightSourceProjectDir * d;
        return lightSourceProjectedPos;
    }

    public Vector3 GetProjectedPosion(Vector3 worldPos)
    {
        Vector3 projectDir = (worldPos - Camera.main.transform.position).normalized;
        float d = Vector3.Dot(worldPos, Vector3.up) / Vector3.Dot(-projectDir, Vector3.up);
        Vector3 projectedPos = worldPos + projectDir * d;
        return projectedPos;
    }

    public Vector3 GetClampedLightSourceProjectedPosion(LightSource lightSource)
    {
        Vector3 lightSourceProjectedPos = GetLightSourceProjectedPosion(lightSource);
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(lightSourceProjectedPos);

        
        return ClampedScreenPosToWorld(ScreenPos.x , ScreenPos.y);
    }

    Vector3 ClampedScreenPosToWorld(float x, float y)
    {
        float minX = (1f - movingRangeFactor) / 2f * Screen.width;
        float maxX = Screen.width - minX;

        float minY = (1f - movingRangeFactor) / 2f * Screen.height;
        float maxY = Screen.height - minY;

        float clampedX = Mathf.Clamp(x, minX, maxX);
        float clampedY = Mathf.Clamp(y, minY, maxY);

        Vector3 clampedWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(clampedX, clampedY,
            Camera.main.nearClipPlane));

        Vector3 clampedProjectedPos = GetProjectedPosion(clampedWorldPos);
        return clampedProjectedPos;
    }
}