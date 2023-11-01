using UnityEngine;

public class FoodRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRandomInitRotaton;
    public bool isRandomRotationSpeed;
    public Vector3 initEulerAngle;
    public Vector3 RotationSpeedInEulerAngle;
    void Start()
    {
        if (isRandomInitRotaton)
        {
            initEulerAngle = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        }
        
        if (isRandomRotationSpeed)
        {
            RotationSpeedInEulerAngle = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
        }
        
        transform.rotation = Quaternion.Euler(initEulerAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(RotationSpeedInEulerAngle * Time.deltaTime);
    }
}
