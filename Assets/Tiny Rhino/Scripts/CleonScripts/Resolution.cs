using UnityEngine;

public class Resolution : MonoBehaviour
{
    public float baseWidth = 1080f;
    public float baseHeigth = 1920f;

    private Transform screenTransform;
    private float baseRatio;
    private float percentScale;

    void Start()
    {
        screenTransform = transform;
        SetScale();
    }

    void SetScale()
    {
        baseRatio = baseWidth / baseHeigth * Screen.height;
        percentScale = Screen.width / baseRatio;
        if (percentScale < 1)
        {
            screenTransform.localScale = new Vector3(screenTransform.localScale.x * percentScale, screenTransform.localScale.y * percentScale, 1);
        }
    }
}
