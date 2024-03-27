using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    bool hasPackage; // Default olarak false olur.
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Bir şeye çarptın");
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            Debug.Log("Paket alındı");
            hasPackage = true;
            Destroy(other.gameObject, timeToDestroy);
            spriteRenderer.color = hasPackageColor;
        }
        else if(other.tag == "Customer" && hasPackage) {
            Debug.Log("Paket müşteriye teslim edildi");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
