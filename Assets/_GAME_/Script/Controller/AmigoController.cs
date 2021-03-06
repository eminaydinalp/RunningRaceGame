using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AmigoController : MonoBehaviour
{
    [SerializeField] private float finishMoveSpeed;
    private GameObject _finishPoint;
    private SpawnControl _spawnControl;
    private Rigidbody _rigidbody;
    
    void OnEnable()
    {
        EventManager.OnFail += ChangeMoveSpeed;
        EventManager.OnWin += DestroyObject;
    }
    void OnDisable()
    {
        EventManager.OnFail -= ChangeMoveSpeed;
        EventManager.OnWin -= DestroyObject;
    }
    void Start()
    {
        _finishPoint = GameObject.FindGameObjectWithTag("Finish");
        _spawnControl = FindObjectOfType<SpawnControl>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       Move();

       if (_finishPoint.transform.position.z < transform.position.z)
       {
           gameObject.SetActive(false);
       }
    }   

    void Move()
    {
        _rigidbody.MovePosition(transform.position + Vector3.back * (Time.fixedDeltaTime * MoveSpeed.instance.amigoSpeed));
    }
    
    private void ChangeMoveSpeed()
    {
        MoveSpeed.instance.amigoSpeed = finishMoveSpeed;
    }
    
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    

}
