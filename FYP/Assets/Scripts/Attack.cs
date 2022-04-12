using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;

    Transform rightHand;
    [SerializeField] GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rightHand = anim.GetBoneTransform(HumanBodyBones.RightHand);
        weapon.transform.parent = rightHand.transform;

        if(Input.GetMouseButton(0))
        {
            anim.Play("NormalAttack01_SwordShield");
        }
        if (Input.GetMouseButton(1))
        {
            anim.Play("NormalAttack02_SwordShield");
        }
    }
}
