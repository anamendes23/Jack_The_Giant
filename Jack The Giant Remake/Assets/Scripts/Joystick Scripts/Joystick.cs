using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    //pressing button
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "Left")
        {
            playerMove.SetMoveLeft(true);
        }
        else
        {
            //right button down
            playerMove.SetMoveLeft(false);
        }
    }

    //releasing button
    public void OnPointerUp(PointerEventData eventData)
    {
        playerMove.StopMoving();
    }
}
