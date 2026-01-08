using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 씬에 생성된 PlayerInput 들 중에서 targetPlayerIndex 에 해당하는 플레이어를 찾아
/// WeaponHudController.BindOwner 에 묶어주는 자동 바인더.
/// 
/// - FindObjectsOfType(T) 사용 안 함 (Obsolete)
/// - FindObjectsByType(T, FindObjectsSortMode.None) 사용
/// </summary>
public sealed class WeaponHudAutoBinder : MonoBehaviour
{
    [Header("Target Player")]
    [Tooltip("0 = 1P, 1 = 2P ... PlayerInput.playerIndex 와 매칭됩니다.")]
    [SerializeField] private int targetPlayerIndex = 0;

    [Header("HUD Reference")]
    [Tooltip("이 HUD 컨트롤러에 해당 PlayerInput 을 바인딩합니다.")]
    [SerializeField] private WeaponHudController hud;

    [Header("Search Options")]
    [Tooltip("PlayerInput 을 찾기 위한 재시도 간격 (초).")]
    [SerializeField] private float retryInterval = 0.25f;

    [Tooltip("이 시간이 지나도 못 찾으면 경고 로그를 출력합니다.")]
    [SerializeField] private float timeoutSeconds = 10f;

    [Tooltip("비활성 PlayerInput 도 포함해서 찾고 싶으면 true.")]
    [SerializeField] private bool includeInactivePlayers = false;

    private Coroutine _bindRoutine;

    private void OnEnable()
    {
        if (hud == null)
        {
            Debug.LogError("[WeaponHudAutoBinder] hud reference is missing.", this);
            return;
        }

        // 바로 한 번 시도 + 필요하면 코루틴으로 재시도
        _bindRoutine = StartCoroutine(BindWhenReady());
    }

    private void OnDisable()
    {
        if (_bindRoutine != null)
        {
            StopCoroutine(_bindRoutine);
            _bindRoutine = null;
        }
    }

    private IEnumerator BindWhenReady()
    {
        float elapsed = 0f;

        // 1) 즉시 1회 시도
        if (TryBindNow())
            yield break;

        // 2) 실패 시 일정 시간 동안 재시도
        while (elapsed < timeoutSeconds)
        {
            yield return new WaitForSecondsRealtime(retryInterval);
            elapsed += retryInterval;

            if (TryBindNow())
                yield break;
        }

        Debug.LogWarning(
            $"[WeaponHudAutoBinder] Failed to bind PlayerInput (playerIndex={targetPlayerIndex}) within {timeoutSeconds:F1} seconds.",
            this);
    }

    /// <summary>
    /// 현재 씬에서 PlayerInput 을 찾아 targetPlayerIndex 와 일치하는 것을 HUD 에 바인딩.
    /// 성공하면 true, 실패하면 false.
    /// </summary>
    private bool TryBindNow()
    {
        // 새 API: FindObjectsByType (정렬 없음이 제일 빠름)
        var inputs = FindObjectsByType<PlayerInput>(FindObjectsSortMode.None);

        for (int i = 0; i < inputs.Length; i++)
        {
            var pi = inputs[i];
            if (pi == null)
                continue;

            if (!includeInactivePlayers && !pi.gameObject.activeInHierarchy)
                continue;

            if (pi.playerIndex != targetPlayerIndex)
                continue;

            // WeaponHudController 가 제공하는 BindOwner 사용
            hud.BindOwner(pi);
            return true;
        }

        return false;
    }
}
