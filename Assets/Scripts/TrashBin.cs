using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public TableCleanupGame gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject); // Destruir la basura
            gameManager.ObjectThrownInTrash();
            Debug.Log("Basura tirada correctamente!");
        }
        else if (other.CompareTag("GreenCan"))
        {
            // Devolver el bote verde a la mesa
            other.transform.position = new Vector3(Random.Range(-0.5f, 0.5f), 1.0f, Random.Range(-0.5f, 0.5f)) + gameManager.table.position;
            Debug.Log("¡No puedes tirar los botes verdes!");
        }
    }
}

