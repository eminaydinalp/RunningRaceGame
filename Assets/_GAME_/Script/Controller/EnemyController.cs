using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float finishMoveSpeed;
    
    private Rigidbody _rigidbody;
    private Camera _mainCamera;
    
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
        _mainCamera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
       Move();

       if (_mainCamera.transform.position.z > transform.position.z)
       {
           gameObject.SetActive(false);
       }
    }   

    void Move()
    {
        _rigidbody.MovePosition(transform.position + Vector3.back * (Time.fixedDeltaTime * MoveSpeed.instance.enemySpeed));
    }
    
    private void ChangeMoveSpeed()
    {
        MoveSpeed.instance.enemySpeed = finishMoveSpeed;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    

}
