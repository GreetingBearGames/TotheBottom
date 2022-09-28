using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //••••••••••••••••••••••••••••••••Variables••••••••••••••••••••••••••••••••
    private Animator animator;
    private CharacterController characterController;
    private float horizontalInput, verticalInput;
    public int hareketKatsayisi = 1;

    public float rotSpeed, jumpSpeed, jumpHorizontalSpeed;
    public float jumpButtonDelay;       //tam olarak kenardan önce veya sonra basması için biraz mühlet veriyoruz.
    [SerializeField] private float ySpeed;
    private float? lastGroundedTime, jumpButtonPressedTime;     //nullable variable böyle oluşturuluyor.
    private float originalStepOffset;
    private bool isJumping, isGrounded;

    [SerializeField] int tersYonDegistirici = 1;     //1 olursa düz; -1 olursa ters gidiyor.
    //••••••••••••••••••••••••••••••••Variables••••••••••••••••••••••••••••••••


    //••••••••••••••••••••••••••••••••Definitions••••••••••••••••••••••••••••••••
    void Awake() 
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isFalling", true);    
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }
    //••••••••••••••••••••••••••••••••Definitions••••••••••••••••••••••••••••••••


    void Update()
    {
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput) * hareketKatsayisi;
        
        float inputMagnitude = Mathf.Clamp01(moveDirection.magnitude);
        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
        moveDirection.Normalize();
        
        ySpeed = ySpeed + Physics.gravity.y * Time.deltaTime;

        if(characterController.isGrounded)  {lastGroundedTime = Time.time;}    //EN SON YERDE OLDUĞU AN
        
        if(Input.GetKey(KeyCode.Space))   {JumpButtonPressed();}    //SPACE'E BASINCA ZIPLAMA
        

        //••••••••••••••••••••••••••••••••Yerde-Havada Kontrolü••••••••••••••••••••••••••••••••
        if(Time.time - lastGroundedTime <= jumpButtonDelay)     //HENÜZ ZIPLAMADI. ŞUAN YERDE
        {
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if(Time.time - jumpButtonPressedTime <= jumpButtonDelay)    //YERDEYDİ. TAM OLARAK ZIPLAMA ANI
            {
                animator.SetBool("isJumping", true);
                isJumping = true;
                ySpeed = jumpSpeed;
                lastGroundedTime = null;
                jumpButtonPressedTime = null;
            }
        }
        else        //ZIPLADI. ŞUAN HAVADA
        {
            characterController.stepOffset = 0;         //havadayken biyerlere tırmanamasın stepi sıfırlıyoruz.
            animator.SetBool("isGrounded", false);
            isGrounded = false;
            if(isJumping && ySpeed < 0 || ySpeed < -2)     //zıplamanın ardından yere düşüyor veya biyerden aşağı düşüyor
            {
                animator.SetBool("isFalling", true);    
            }
        }
        //••••••••••••••••••••••••••••••••Yerde-Havada Kontrolü••••••••••••••••••••••••••••••••


        //••••••••••••••••••••••••••••••••Yatay Yönde Hareket••••••••••••••••••••••••••••••••
        if(moveDirection != Vector3.zero)   //eğer hareket varsa
        {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(moveDirection,Vector3.up);  //ilgili hareket yönüne yüzün dönmesi
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        //••••••••••••••••••••••••••••••••Yatay Yönde Hareket••••••••••••••••••••••••••••••••

        //••••••••••••••••••••••••••••••••Havadayken Hareket••••••••••••••••••••••••••••••••
        if(isGrounded == false)
        {
            Vector3 velocity = moveDirection * jumpHorizontalSpeed;
            velocity.y = ySpeed;

            characterController.Move(velocity * Time.deltaTime);
        }
        //••••••••••••••••••••••••••••••••Havadayken Hareket••••••••••••••••••••••••••••••••
    }


    //••••••••••••••••••••••••••••••••Yerdeyken Hareket••••••••••••••••••••••••••••••••
    private void OnAnimatorMove() 
    {
        if(isGrounded)
        {
            Vector3 finalMoveAmount = animator.deltaPosition;
            //finalMoveAmount = AdjustMoveAmountToSlope(finalMoveAmount);
            finalMoveAmount.y += ySpeed * Time.deltaTime;

            characterController.Move(finalMoveAmount);
        }
    }
    //••••••••••••••••••••••••••••••••Yerdeyken Hareket••••••••••••••••••••••••••••••••


    /*//••••••••••••••••••••••••••••••••Eğer Hareket Eğimli Hattaysa••••••••••••••••••••••••••••••••
    private Vector3 AdjustMoveAmountToSlope(Vector3 finalMoveAmount)
    {
        var ray = new Ray(transform.position, Vector3.down); //bulunduğu bölgeden aşağı doğru bir ışın oluşturdu

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
        {
            var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            var adjustedMoveAmount = slopeRotation * finalMoveAmount;

            if(adjustedMoveAmount.y < 0)
            {
                return adjustedMoveAmount;
            }
        }
        return finalMoveAmount;
    }
    *///••••••••••••••••••••••••••••••••Eğer Hareket Eğimli Hattaysa••••••••••••••••••••••••••••••••


    //••••••••••••••••••••••••••••••••Jump Butonu••••••••••••••••••••••••••••••••
    public void JumpButtonPressed()
    {
        if(hareketKatsayisi == 1)
        {
            jumpButtonPressedTime = Time.time;
        }
    }
    //••••••••••••••••••••••••••••••••Jump Butonu••••••••••••••••••••••••••••••••


    //••••••••••••••••••••••••••••••••D-Pad Kontrolü••••••••••••••••••••••••••••••••
    public void MovetoLeftDown()  {horizontalInput = -0.9f * tersYonDegistirici;}
    public void MovetoRightDown()  {horizontalInput = 0.9f * tersYonDegistirici;}
    public void MovetoForwardDown()  {verticalInput = 0.9f * tersYonDegistirici;}
    public void MovetoBackwardDown()  {verticalInput = -0.9f * tersYonDegistirici;}
    public void MovetoAnyDirectionUp()  {horizontalInput = 0;    verticalInput = 0;}
    //••••••••••••••••••••••••••••••••D-Pad Kontrolü••••••••••••••••••••••••••••••••

}
