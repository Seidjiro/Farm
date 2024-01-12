using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    //�������� ���������
    [SerializeField] private float speedMove;
    
    //��������� ��������� ��� ��������� 
    private float gravityForse; //���������� ��������� 
    private Vector3 moveVector3; //����������� �������� ���������

    //������ �� ����������
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
    /// ����� ����������� ���������
    /// </summary>
    private void CharacterMove()
    {
        //����������� �� �����������
        moveVector3 = Vector3.zero;
        moveVector3.x = mContr.Horizontal() * -speedMove;
        moveVector3.z = mContr.Vertical() * -speedMove;

        //�������� ������������ ���������
        if (moveVector3.x != 0 || moveVector3.z != 0) ch_animator.SetBool("Move", true);
        else ch_animator.SetBool("Move", false);

        //������� ��������� � ������� ����������� �����������
        //if (Vector3.Angle(Vector3.forward, moveVector3) > 1f || Vector3.Angle(Vector3.forward, moveVector3) == 0)
        //{
        //    Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector3, speedMove, 0.0f);
        //    transform.rotation = Quaternion.LookRotation(direct);
        //}

        moveVector3.y = gravityForse;
        ch_Controller.Move(moveVector3 * Time.deltaTime); //����� ������������ �� ����������
    }

    /// <summary>
    /// ����� ����������
    /// </summary>
    private void GamingGrarity()
    {
        if (!ch_Controller.isGrounded) gravityForse -= 20f * Time.deltaTime;
        else gravityForse = -1f;
    }
}

