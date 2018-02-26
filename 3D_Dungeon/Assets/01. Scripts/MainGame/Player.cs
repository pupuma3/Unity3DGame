using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    override public void Init()
    {
        base.Init();
        _characterType = eCharacterType.PLAYER;
    }

    override public void UpdateCharacter()
    {
        base.UpdateCharacter();
        UpdateInput();
    }

    void UpdateInput()
    {
        if (InputManager.Instance.IsMouseDown())
        {
            Vector3 mousePosition = InputManager.Instance.GetCursorPosition();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hitInfo;
            LayerMask layerMask = (1 << LayerMask.NameToLayer("Ground")) |
                                (1 << LayerMask.NameToLayer("Character"));
            if (Physics.Raycast(ray, out hitInfo, 100.0f, layerMask))
            {
                if( LayerMask.NameToLayer("Ground") == hitInfo.collider.gameObject.layer )
                {
                    _targetPosition = hitInfo.point;
                    _stateList[_stateType].UpdateInput();
                }
                else if (LayerMask.NameToLayer("Character") == hitInfo.collider.gameObject.layer)
                {
                    HitArea hitArea = hitInfo.collider.gameObject.GetComponent<HitArea>();
                    Character character = hitArea.GetCharacter();
                    switch (character.GetCharacterType())
                    {
                        case eCharacterType.MONSTER:
                            // 적으로 파악
                            Debug.Log("Monster");
                            _targetPosition = hitInfo.collider.gameObject.transform.position;
                            ChangeState(eState.CHASE);
                            break;
                    }
                }
            }
        }
        if(InputManager.Instance.IsAttackButtonDown())
        {
            ChangeState(eState.ATTACK);
        }
    }
}
