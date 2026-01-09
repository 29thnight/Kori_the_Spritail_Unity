using UnityEngine;
using UnityEngine.InputSystem;

public sealed class WeaponHudController : MonoBehaviour
{
    [Header("Slot Views (0~3)")]
    [SerializeField] private WeaponSlotItemView[] slotViews = new WeaponSlotItemView[4];

    [Header("Icon Sets")]
    [SerializeField] private WeaponIconSet defaultSet;
    [SerializeField] private WeaponIconSet meleeSet;
    [SerializeField] private WeaponIconSet rangedSet;
    [SerializeField] private WeaponIconSet bombSet;

    private PlayerInput _owner;
    private player _player;   // ★ 클래스명이 소문자 player

    public PlayerInput Owner => _owner;

    /// <summary>
    /// WeaponHudAutoBinder 에서 호출
    /// </summary>
    public void BindOwner(PlayerInput owner)
    {
        _owner = owner;
        if (_owner == null)
        {
            Debug.LogError("[WeaponHudController] BindOwner called with null.", this);
            return;
        }

        // ★ 플레이어 스크립트 클래스명이 player 라면 꼭 이렇게!
        _player = _owner.GetComponent<player>();
        if (_player == null)
        {
            Debug.LogError(
                $"[WeaponHudController] Could not find 'player' component on PlayerInput (playerIndex={_owner.playerIndex}).",
                this
            );
            return;
        }

        // 슬롯 번호 UI 초기화
        for (int i = 0; i < slotViews.Length; i++)
        {
            if (slotViews[i] != null)
                slotViews[i].SetSlotIndex(i);
        }

        RefreshAll();
    }

    private void Update()
    {
        if (_owner == null || _player == null)
            return;

        RefreshAll();
    }

    private void RefreshAll()
    {
        var weapons = _player.Weapons;  // ★ player 스크립트의 public List<weapon> Weapons 사용
        int selectedIndex = Mathf.Clamp(_player.SelectedWeaponIndex, 0, slotViews.Length - 1);

        for (int slot = 0; slot < slotViews.Length; slot++)
        {
            var view = slotViews[slot];
            if (view == null)
                continue;

            weapon w = null;
            if (weapons != null && slot < weapons.Count)
                w = weapons[slot];

            bool hasWeapon = (w != null) && !w.isBreak;
            bool selected = (slot == selectedIndex);

            float durability01 = 0f;
            int curDur = 0;
            WeaponIconSet set = defaultSet;

            if (w != null)
            {
                durability01 = w.HudDurability01; // 게이지용 (0~1)
                curDur = w.curDur;                // ★ 텍스트용 (원본 내구도)
                set = GetIconSet(w.HudSlotKind);
            }

            view.ApplySnapshot(hasWeapon, selected, durability01, set);

            // ★ 텍스트는 curDur 기준으로
            if (hasWeapon)
                view.SetDurabilityNumber(curDur);
            else
                view.SetDurabilityNumber(0); // 내부에서 hasWeapon=false면 알아서 빈 문자열 찍음
        }

    }

    private WeaponIconSet GetIconSet(WeaponSlotKind kind)
    {
        return kind switch
        {
            WeaponSlotKind.Default => defaultSet != null ? defaultSet : meleeSet,
            WeaponSlotKind.Melee => meleeSet != null ? meleeSet : defaultSet,
            WeaponSlotKind.Ranged => rangedSet != null ? rangedSet : defaultSet,
            WeaponSlotKind.Bomb => bombSet != null ? bombSet : defaultSet,
            _ => defaultSet
        };
    }
}
