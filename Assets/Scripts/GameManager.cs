using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string tranformMode;

    public void SetModeTransform(string mode)
    {
        tranformMode = mode;
    }
}
