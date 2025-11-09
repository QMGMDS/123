using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject attackHighlight;
    public GameObject skillHighlight;
    public GameObject defenseHighlight;
    public GameObject itemHighlight;
    public GameObject escapeHighlight;

    #region 鼠标的移入移出
    //实现条件:
    //1.using UnityEngine.EventSystems 调用
    //2.IPointerEnterHandler, IPointerExitHandler 接口的实现
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("鼠标进入了！");
        //attackHighlight.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //attackHighlight.SetActive(false);
    }
    #endregion

}
