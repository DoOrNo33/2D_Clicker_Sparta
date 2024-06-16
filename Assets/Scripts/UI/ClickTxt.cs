using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickTxt : MonoBehaviour
{
    public TextMeshProUGUI txt;

    private Animator anim;
    private int HashClick;

    private void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.ClickEvent += SetText;
        GameManager.Instance.ClickEvent += PlayAnim;
        anim = GetComponent<Animator>();
        HashClick = Animator.StringToHash("Click");
    }

    public void SetText(int Value)
    {
        txt.text = Value.ToString();
    }

    public void PlayAnim(int Value)
    {
        anim.SetTrigger(HashClick);
    }
}