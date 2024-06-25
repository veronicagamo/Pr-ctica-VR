using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableCleanupGame : MonoBehaviour
{
    public Transform table;
    public TMP_Text trashCounterText; 
    private int totalObjects;
    private int greenCansRemaining;
    private int trashObjectsThrown;

    void Start()
    {
        totalObjects = table.childCount;
        greenCansRemaining = 0;
        trashObjectsThrown = 0;

        foreach (Transform child in table)
        {
            if (child.CompareTag("GreenCan"))
            {
                greenCansRemaining++;
            }
        }

        UpdateTrashCounter(); 
    }

    void Update()
    {
        int greenCansOnTable = 0;

        foreach (Transform child in table)
        {
            if (child.position.y > table.position.y && child.CompareTag("GreenCan"))
            {
                greenCansOnTable++;
            }
        }

        if (greenCansOnTable == greenCansRemaining && trashObjectsThrown == totalObjects - greenCansRemaining)
        {
            Debug.Log("Fin del juego");

        }
    }

    public void ObjectThrownInTrash()
    {
        trashObjectsThrown++;
        UpdateTrashCounter(); 
    }

    public void UpdateTrashCounter()
    {
        int trashObjectsRemaining = totalObjects - greenCansRemaining - trashObjectsThrown;
        trashCounterText.text = "Objetos de Basura Restantes: " + trashObjectsRemaining;
    }
}
