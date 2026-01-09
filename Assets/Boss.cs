using Unity.Behavior;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BehaviorGraphAgent graphAgent;
    private Blackboard blackboard;
    private BlackboardVariable<int> curHP;
    private InputActionMap actionMap;

    public bool isDead = false;
    public float _deadActionWait = 2f;
    private float _count = 0;
    public int CurrentHP => curHP.Value;

    void Start()
    {
        graphAgent = GetComponent<BehaviorGraphAgent>();
        actionMap = GetComponent<PlayerInput>().currentActionMap;
        actionMap.AddBinding("Damege", "<Keyboard>/space");
    }

    // Update is called once per frame
    void Update()
    {

        bool check = graphAgent.GetVariable<int>("curHP", out curHP);

        /*if (!check) {
            Debug.LogError("Failed to get curHP variable from blackboard.");
        }
        else {
            Debug.Log("Successfully got curHP variable from blackboard." + curHP.Value);
        }*/

        if (isDead)
        {
            //todo
            _count += Time.deltaTime;
            if (_count >= _deadActionWait) {

                Debug.LogError("Boss is Dead todo Action");
                //todo
                SceneManager.LoadScene("ClearScene");
            }
        }



    }

    public void Damege(int damage)
    {
        curHP.Value -= damage;

        if (curHP.Value <= 0)
        {
            Debug.LogError($"lower HP 0");
            curHP.Value = 0;
        }

        graphAgent.SetVariableValue<int>("curHP", curHP.Value);
        Debug.Log($"Boss took damage { damage }, current HP: { curHP.Value }");
    }

    

}
