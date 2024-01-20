using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 0.01f;

    public GameObject targetObject;
    private Quaternion originalRotation;
    private Quaternion shopRotation;

    [SerializeField] private float timer;
    [SerializeField] private float timerLimit;



    [SerializeField] public bool isPlaying = false;
    [SerializeField] public bool onShop = false;
    [SerializeField] private bool onEnnemie = true;

    [SerializeField] private bool turnCameraToShop = false;
    [SerializeField] private float amountToRotate = 90f;

    void Start()
    {

        
        originalRotation = transform.rotation;
        shopRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position,Vector3.up);
        
    }

    public void StartRotationToShop()
    {
        if(isPlaying == false)
        {
            

            if (onEnnemie)
            {
                StartCoroutine(RotateCameraToShop());
            }
            if (onShop)
            {
                StartCoroutine(RotateCameraToEnnemie());
            }
        }
        
    }

    public IEnumerator RotateCameraToShop()
    {

        onEnnemie = false;
        isPlaying = true;
        while (timer != timerLimit)
        {
            transform.rotation = Quaternion.Slerp(originalRotation, shopRotation, timer / timerLimit);
            
            timer += speed;
            if(timer >= timerLimit)
            {
                onShop = true;
                timer = timerLimit;
            }

            yield return null;
        }
        timer = 0;

        isPlaying=false;
        yield return null;

    }

    // Does the same but for the counter rotation, could have probably find a better way to do that with one function instead
    // RotateCameraFromTo(bool correspondingBool, Quaternion from, Quaternion to)
    public IEnumerator RotateCameraToEnnemie()
    {

        onShop = false;
        isPlaying = true;
        while (timer != timerLimit)
        {
            transform.rotation = Quaternion.Slerp(shopRotation, originalRotation, timer / timerLimit);

            timer += speed;
            if (timer >= timerLimit)
            {
                onEnnemie = true;
                timer = timerLimit;
            }

            yield return null;
        }
        timer = 0;

        isPlaying = false;
        yield return null;

    }
}
