using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// INHERITANCE
public class Goodie : Target
{
    //POLYMPORHISM
    void Start()
    {
        int points = Random.Range(1, 5);
        SerializedObject haloComponent = new SerializedObject(GetComponent("Halo"));
        haloComponent.FindProperty("m_Size").floatValue = (points/2.0f) - 0.5f;
        haloComponent.ApplyModifiedProperties();
        pointValue = points;
        
        Initialize();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameManager.GameOver();
    }
}
