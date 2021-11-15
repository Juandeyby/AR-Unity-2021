using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreated : MonoBehaviour
{
    [SerializeField] private Transform _objectCreated;
    [SerializeField] private Transform _box;

    public Transform GetBox()
    {
        return _box;
    }
}
