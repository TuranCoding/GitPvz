using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    private GameObject darkBg;
    private GameObject progressBar;
    public GameObject objectPrefab;
    public GameObject curGameObject;
    public float waitTime;
    public float sunNum;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("progress").gameObject;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDark();
    }
    void UpdateProgress()
    {
        float per = Mathf.Clamp(timer / waitTime, 0, 1);
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }

    void UpdateDark()
    {
        //太阳数量是否满足
        if (progressBar.GetComponent<Image>().fillAmount == 0)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }

    }

    //拖拽开始 鼠标按下的一瞬间
    public void OnBeginDrag(BaseEventData data)
    {
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject = Instantiate(objectPrefab);
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);

    }

    //拖拽过程
    public void OnDarg(BaseEventData data)
    {
        if (curGameObject == null) return;
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObject.transform.position = TranlateScreenToWorld(pointerEventData.position);
    }

    //拖拽结束
    public void OnEndDarg(BaseEventData data)
    {

        if (curGameObject == null) return;
        PointerEventData pointerEventData = data as PointerEventData;
        Collider2D[] col = Physics2D.OverlapPointAll(TranlateScreenToWorld(pointerEventData.position));
        foreach (Collider2D c in col)
        {
            if (c.tag == "Land" && c.transform.childCount == 0)
            {
                curGameObject.transform.parent = c.transform;
                curGameObject.transform.localPosition = Vector3.zero;
                curGameObject = null;
                break;
            }
        }

        if (curGameObject != null)
        {
            Destroy(curGameObject);
            curGameObject = null;
        }

    }

    public static Vector3 TranlateScreenToWorld(Vector3 position)
    {
        Vector3 cameraTranlatePos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraTranlatePos.x, cameraTranlatePos.y, 0);
    }

}
