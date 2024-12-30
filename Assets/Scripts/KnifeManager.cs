
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Vector2 knifeIconPosition;

    [SerializeField] private Color activeColor;
    [SerializeField] private Color disableColor;

    [SerializeField] private int knifeCount;

    private int knifeIndex = 0;

    private void Start()
    {
        CreateKnifes();
        CreateKnifeIcons();
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

    private void CreateKnifeIcons()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(knifeIconPrefab, knifeIconPosition, knifeIconPrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = activeColor;
            knifeIconPosition.y += 0.5f;
            knifeList.Add(newKnifeIcon);
        }
    }

    public void SetDisableKnifeIconColor()
    {
        knifeIconList[(knifeIconList.Count - 1) - knifeIndex].GetComponent<SpriteRenderer>().color = disableColor;
    }

    public void SetActiveKnife()
    {
        if (knifeIndex < knifeCount)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
