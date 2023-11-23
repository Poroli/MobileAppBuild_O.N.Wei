using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    
    [SerializeField] private Color touchColor;
    [SerializeField] private string tagColorChangeGO;
    private GameObject[] tmpGOs;

    public void ChangeColor(GameObject GO)
    {
        GO.GetComponent<MeshRenderer>().material.color = touchColor;
    }

    public void ButtonChangeColor()
    {
        foreach (GameObject tmpGO in tmpGOs)
        {
            if (tmpGO.GetComponent<MeshRenderer>().material.color != Color.green)
            {
                tmpGO.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                tmpGO.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void Start()
    {
        tmpGOs = GameObject.FindGameObjectsWithTag(tagColorChangeGO);

        foreach (GameObject go in tmpGOs)
        {
            go.AddComponent<ColorChangeClient>().colorChange = this;
        }
    }
}

public class ColorChangeClient : MonoBehaviour
{
    public ColorChange colorChange;

    private void OnMouseDown()
    {
        colorChange.ChangeColor(gameObject);
    }
}
