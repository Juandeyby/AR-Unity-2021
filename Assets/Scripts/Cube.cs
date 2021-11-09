using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private int tranformObject = 0;
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

                switch (tranformObject)
                {
                    case 0 :
                        transform.localScale = new Vector3(distance, distance, distance) * 0.001f;
                        break;
                    case 1:
                        transform.Rotate(distance * 0.1f, 0.0f, 0.0f, Space.Self);
                        break;
                    case 2:
                        transform.localPosition = new Vector3(distance * 0.001f, 0 , 0);
                        break;
                }
                _text.SetText(distance.ToString());
            }
        }
        
        //transform.localRotation = Quaternion.Euler(0.001f, 0, 0);
    }

    public void ScaleOnClick()
    {
        tranformObject = 0;
    }

    public void RotationOnCLick()
    {
        tranformObject = 1;
    }

    public void PositionOnClick()
    {
        tranformObject = 2;
    }

    // private void OnMouseDown()
    // {
    //     Destroy(this.gameObject);
    // }
}
