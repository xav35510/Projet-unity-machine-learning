using UnityEngine;

//une classe qui servira à ne pas multiplier les calculs

public class Utile : MonoBehaviour
{

    private Vector3 mousePos;
    public float mouseAngle;


    void Update()
    {
        captureMousePos();
        calculMouseAngle();
    }
    private void captureMousePos()
    {
        Vector3 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 retBis = ret;
        ret *=2;
        ret -= Vector3.one;
        float max = 0.9f;
        if(Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max){
            ret = ret.normalized;
        }

        mousePos = ret;

    }

    private void calculMouseAngle()
    {
        mouseAngle = Mathf.Atan2(mousePos.y,mousePos.x);
    }

    public Vector3 getMousePos()
    {
        return mousePos;    
    }

    public float getMouseAngle()
    {
        return mouseAngle;
    }
}
