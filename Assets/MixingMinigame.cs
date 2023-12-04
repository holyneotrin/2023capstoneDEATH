using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingMinigame : MonoBehaviour
{
    public GameObject MixingTarget1;
    public GameObject MixingTarget2;
    public GameObject MixingTarget3;
    public GameObject MixingTarget4;

    private LineRenderer lineRenderer;


    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        MakeNewMixingPattern();
    }

    [ContextMenu("New Mixing Pattern")]
    public void MakeNewMixingPattern() {
        SetRandomPosition(MixingTarget1);
        SetRandomPosition(MixingTarget2);
        SetRandomPosition(MixingTarget3);
        SetRandomPosition(MixingTarget4);

        List<Vector3> pos = new List<Vector3>();
        pos.Add(MixingTarget1.transform.position);
        pos.Add(MixingTarget2.transform.position);
        pos.Add(MixingTarget3.transform.position);
        pos.Add(MixingTarget4.transform.position);

        lineRenderer.SetPositions(pos.ToArray());
    }

    void SetRandomPosition(GameObject obj) {
        // Define the ranges for x, y, and z coordinates
        float randomX = Random.Range(-5f, 4f);
        float randomY = Random.Range(3.5f, -2f);
        float fixedZ = 1f; // Z coordinate is fixed at 1

        // Set the GameObject's position to the random values
        obj.transform.position = new Vector3(randomX, randomY, fixedZ);
    }
}
