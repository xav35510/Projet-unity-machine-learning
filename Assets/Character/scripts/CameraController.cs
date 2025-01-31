using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; //joueur que la caméra suit
    public Utile utile;

    private Vector3 mousePos, target, refVel, shakeOffset;

    float cameraDist = 1f;
    float smoothTime = 0.1f, zStart;
    float shakeMag,shakeTimeEnd;
    Vector3 shakeVector;
    bool shaking;

    void Start()
    {
        target = player.position;
        zStart = transform.position.z;
        
    }

    void Update()
    {
        mousePos = utile.getMousePos();
        shakeOffset = UpdateShake();
        target = UpdateTargetPos();
        UpdateCameraPosition();
    }

    Vector3 UpdateTargetPos(){
        Vector3 mouseOffset = mousePos * cameraDist;
        Vector3 ret = player.position + mouseOffset;
        ret += shakeOffset;
        ret.z = zStart;
        return ret;
    }

    void UpdateCameraPosition(){
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel,smoothTime);
        transform.position = tempPos;
    }
    public void Shake(Vector3 direction, float magnitude, float length){
        shaking = true;
        shakeVector = direction;
        shakeMag = magnitude;
        shakeTimeEnd = Time.time  + length;
    }
    Vector3 UpdateShake(){
        if(!shaking || Time.time > shakeTimeEnd){
            shaking = false;
            return Vector3.zero;
        }
        Vector3 tempsOffset = shakeVector;
        tempsOffset *= shakeMag;
        return tempsOffset;
    }
}
