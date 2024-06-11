using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PopupText : MonoBehaviour
{

    [SerializeField] private Vector3 randomVector;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0.25f, 0.25f, 0);
        transform.localRotation = Quaternion.identity;
        var getRandomX = Random.Range(0, randomVector.x);
        var getRandomY = Random.Range(0, randomVector.y);
        //transform.DOMove(new Vector3(getRandomX, getRandomY, 0), 0.3f).SetRelative();
        transform.DOScale(new Vector3(getRandomX, getRandomY, 0), 0.3f).SetRelative();
    }
}
