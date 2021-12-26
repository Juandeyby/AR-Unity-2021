using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectARCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain")) return;
        other.transform.parent = transform.parent;
        //var corner = 0.01f - (other.transform.localScale.x / 100f);
        //other.transform.localPosition = new Vector3(corner, other.transform.localPosition.y, corner);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Terrain")) return;
        other.transform.parent = null;
    }
}
