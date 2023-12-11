using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingMinigame : MonoBehaviour
{
    public GameObject[] MixingTargets;
    
    private LineRenderer lineRenderer;
    private int lastClickedIndex = -1;


    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        MakeNewMixingPattern();
    }

    void Update() {
        // Check for left mouse button down
        if (Input.GetMouseButton(0)) {
            // Get the mouse position in world coordinates
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform a 2D raycast at the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Check if the raycast hit a collider
            if (hit.collider != null 
             && hit.collider.CompareTag("HoverTarget") ) {

                // Get Mixing Target componenet
                MixingTarget mixingTarget =  hit.collider.GetComponent<MixingTarget>();

                if (mixingTarget != null && mixingTarget.clicked == false) {
                    mixingTarget.clicked = true;

                    lastClickedIndex++;

                    Debug.Log("Target Hit");

                    if (checkTargets()) {
                        ReactionProfile.instance.QueueReaction(new ReactionCommand(ReactionProfile.instance.successSprite));
                        MakeNewMixingPattern();
                    }
                }
            }
        }
    }


    private bool checkTargets() {
        foreach (GameObject target in MixingTargets) {
            if (target.GetComponent<MixingTarget>().clicked == false) {
                return false;
            }
        }

        return true;
    }

    [ContextMenu("New Mixing Pattern")]
    public void MakeNewMixingPattern() {
        lastClickedIndex = -1;

        List<Vector3> pos = new List<Vector3>();
        foreach (GameObject target in MixingTargets) {
            SetRandomPosition(target);
            target.GetComponent<MixingTarget>().clicked = false;
            pos.Add(target.transform.position);
        }

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
