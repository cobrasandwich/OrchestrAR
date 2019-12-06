using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject hoveredObject;
    Color original;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("MOUSE PRESSED " + hit.collider.gameObject.name);
            }

            GameObject hitObject = hit.collider.gameObject;
            SelectObject(hitObject);
        }
        else {
            ClearSelection();
        }
    }

    void SelectObject(GameObject obj) {

        //check if already selected
        if (hoveredObject != null) {
            if(obj == hoveredObject) {
                return;
            }
            ClearSelection();
        }

        hoveredObject = obj;

        Renderer rs = hoveredObject.GetComponent<Renderer>();
        Material m = rs.material;
        if(rs.material.color != Color.cyan) {
            original = rs.material.color;
        }
        m.color = Color.cyan;
        rs.material = m;
    }

    void ClearSelection() {
        if(hoveredObject == null) {
            return;
        }

        Renderer rs = hoveredObject.GetComponent<Renderer>();
        rs.material.color = original;

        hoveredObject = null;
    }
}
