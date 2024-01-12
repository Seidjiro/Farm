using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    //ќсновные параметры
    [SerializeField] private float speedMove;
    
    //ѕараметры геймплей€ дл€ персонажа 
    private float gravityForse; //гравитаци€ персонажа 
    private Vector3 moveVector3; //направление движени€ персонажа

    //—сылки на компоненты
    private CharacterController ch_Controller;
    private Animator ch_animator;
    private MobileContr mContr;

    private void Start()
    {
        ch_Controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        mContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileContr>();
    }

    private void Update()
    {
        CharacterMove();
        GamingGrarity();
    }

    /// <summary>
    /// ћетод перемещени€ персонажа
    /// </summary>
    private void CharacterMove()
    {
        //перемещение по поверхности
        moveVector3 = Vector3.zero;
        moveVector3.x = mContr.Horizontal() * -speedMove;
        moveVector3.z = mContr.Vertical() * -speedMove;

        //анимаци€ передвижени€ персонажа
        if (moveVector3.x != 0 || moveVector3.z != 0) ch_animator.SetBool("Move", true);
        else ch_animator.SetBool("Move", false);

        //поворот персонажа в сторону направлени€ перемещени€
        //if (Vector3.Angle(Vector3.forward, moveVector3) > 1f || Vector3.Angle(Vector3.forward, moveVector3) == 0)
        //{
        //    Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector3, speedMove, 0.0f);
        //    transform.rotation = Quaternion.LookRotation(direct);
        //}

        moveVector3.y = gravityForse;
        ch_Controller.Move(moveVector3 * Time.deltaTime); //метод передвижени€ по напрвлению
    }

    /// <summary>
    /// метод гравитации
    /// </summary>
    private void GamingGrarity()
    {
        if (!ch_Controller.isGrounded) gravityForse -= 20f * Time.deltaTime;
        else gravityForse = -1f;
    }
}

