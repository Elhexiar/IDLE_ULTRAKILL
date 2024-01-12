using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 0.01f;
     private Quaternion _originalRotation;
     private Quaternion _currentRotation;
     private Quaternion _ShopRotation;
    public GameObject targetObject;
    [SerializeField] private Camera _camera;
    [SerializeField] private float timer;
    [SerializeField] private float timerLimit;

    [SerializeField] private GameObject _ennemieShopTarget;

    [SerializeField] public bool _isPlaying = false;
    [SerializeField] public bool _onShop = false;
    [SerializeField] private bool _onEnnemie = true;

    [SerializeField] private Vector3 aled;
    [SerializeField] private bool turnCameraToShop = false;
    [SerializeField] private float amountToRotate = 90f;

    void Start()
    {

        Debug.Log(transform.rotation.y);
        _originalRotation = transform.rotation;
        _ShopRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position,Vector3.up);
        
    }

    // Update is called once per frame
    void Update()
    {
        aled = _ShopRotation.eulerAngles;
    }

    public void StartRotationToShop()
    {
        if(_isPlaying == false)
        {
            

            if (_onEnnemie)
            {
                StartCoroutine(RotateCameraToShop());
            }
            if (_onShop)
            {
                StartCoroutine(RotateCameraToEnnemie());
            }
        }
        
    }

    public IEnumerator RotateCameraToShop()
    {
        
        Debug.Log("StartRotationToShop");
        _onEnnemie = false;
        _isPlaying = true;
        while (timer != timerLimit)
        {
            transform.rotation = Quaternion.Slerp(_originalRotation, _ShopRotation, timer / timerLimit);
            
            timer += speed;
            if(timer >= timerLimit)
            {
                _onShop = true;
                timer = timerLimit;
                yield return null;
            }

            yield return null;
        }
        timer = 0;

        _isPlaying=false;
        yield return null;

    }
    public IEnumerator RotateCameraToEnnemie()
    {
        Debug.Log("StartRotationToShop");
        _onShop = false;
        _isPlaying = true;
        while (timer != timerLimit)
        {
            transform.rotation = Quaternion.Slerp(_ShopRotation, _originalRotation, timer / timerLimit);

            timer += speed;
            if (timer >= timerLimit)
            {
                _onEnnemie = true;
                timer = timerLimit;
                yield return null;
            }

            yield return null;
        }
        timer = 0;

        _isPlaying = false;
        yield return null;

    }
}
