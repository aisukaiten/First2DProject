using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 15f; // SerializeField , Inspector üzerinden değişkenleri değiştirmemiz için kullanılıyor.
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 25f;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost") {
            moveSpeed = boostSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
            moveSpeed = slowSpeed;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // Time.deltaTime kullanmamızın sebebi her bilgisayarda aynı şekilde ilerlemesi (Kare Hızı Farklılığı)
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, -steerAmount);
    }
}
