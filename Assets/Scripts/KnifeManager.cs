
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();

    [SerializeField] private GameObject knifePrefab;

    [SerializeField] private int knifeCount;

    private int knifeIndex;

    private void Start()
    {
        CreateKnifes();
    }

    private void CreateKnifes()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }
        knifeList[0].SetActive(true);
    }

    public void SetActiveKnife()
    {
        
    }
}
