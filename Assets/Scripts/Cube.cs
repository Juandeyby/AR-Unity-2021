using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private bool scaleActive;
    private Vector2 startPos;
    private Vector2 direction;
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }
            
            if (touch.phase == TouchPhase.Moved)
            {
                var distance = Vector2.Distance(touch.position, startPos);
                if (scaleActive)
                    transform.localScale = new Vector3(distance, distance, distance) * 0.001f;
                else
                    transform.Rotate(distance * 0.1f, 0.0f, 0.0f, Space.Self);
                _text.SetText(distance.ToString());
            }
        }
        
        transform.localRotation = Quaternion.Euler(0.001f, 0, 0);
    }

    public void ScaleOnClick()
    {
        scaleActive = true;
    }

    public void RotationOnCLick()
    {
        scaleActive = false;
    }

    // private void OnMouseDown()
    // {
    //     Destroy(this.gameObject);
    // }
}
