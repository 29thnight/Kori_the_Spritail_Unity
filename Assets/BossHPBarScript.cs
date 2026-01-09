using UnityEngine;
using UnityEngine.UI;

public class BossHPBarScript : MonoBehaviour
{
    [SerializeField] Image hpFillImage; // Fill 타입 Image
    [SerializeField] Boss bossScript;
    const int maxHP = 100;
    /// <summary>
    /// 현재 HP / 최대 HP 비율로 HPBar 갱신
    /// </summary>
    public void SetHP(float currentHP, float maxHP)
    {
        if (hpFillImage == null || maxHP <= 0f)
            return;

        float percent = Mathf.Clamp01(currentHP / maxHP);
        hpFillImage.fillAmount = percent;
    }

    /// <summary>
    /// 퍼센트(0~1) 직접 지정
    /// </summary>
    public void SetHPPercent(float percent)
    {
        if (hpFillImage == null)
            return;

        hpFillImage.fillAmount = Mathf.Clamp01(percent);
    }

    private void Awake()
    {
        if (null == bossScript)
            Debug.LogError("fucked up");
    }

    private void Update()
    {
        SetHP(bossScript.CurrentHP, maxHP);
    }
}
