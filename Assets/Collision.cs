using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    [SerializeField] float destroyDelay = 0.5f;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.gameObject.name);
        Debug.Log("You hit me!!! ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Package") && !hasPackage) {
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
            Debug.Log("PACKAGE");
            hasPackage = true;
        }
        if (other.tag.Equals("Customer") && hasPackage) {
            spriteRenderer.color = noPackageColor;
            Debug.Log("Delivered Package");
            hasPackage = false;
        }
    }
}
