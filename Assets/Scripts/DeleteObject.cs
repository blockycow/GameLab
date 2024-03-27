using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDelete;

    [SerializeField] private float seconds = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (objectToDelete == null)
        {
            objectToDelete = this.gameObject;
        }
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
