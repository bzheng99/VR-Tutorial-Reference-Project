using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField]
    private GameObject flamePrefab;
    
    public GameObject FlamePrefab => flamePrefab;
}