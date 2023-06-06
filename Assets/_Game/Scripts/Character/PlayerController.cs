using UnityEngine;

public class PlayerController : Character
{
    private float joystickRadius = 120f;
    private Vector3 firstMousePosition;
    private Vector3 currentMousePosition;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject joystickBackground;
    [SerializeField] private GameObject joystickHandle;
    public bool isGround;
    public float raycastLength;
    public void Start()
    {
        speed = 15f;
        ChangeColor(MaterialType.Blue);
    }

    protected override void Update()
    {

        base.Update();
        isGround = CheckGround();


        if (isFalling == false && joystick.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstMousePosition = Input.mousePosition;
                joystick.transform.position = firstMousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                currentMousePosition = Input.mousePosition;
                direction = currentMousePosition - firstMousePosition;
                joystickHandle.transform.position = currentMousePosition;
                if (Vector3.Distance(joystickHandle.transform.position, joystickBackground.transform.position) > joystickRadius)
                {
                    joystickHandle.transform.position = joystickBackground.transform.position - (joystickBackground.transform.position - joystickHandle.transform.position).normalized * joystickRadius;
                }
                if (Vector3.Distance(joystickHandle.transform.position, joystickBackground.transform.position) > joystickRadius / 2)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y));
                    ChangeAnim("run");
                    if (onBridge && direction.y > 0.1f)
                    {
                        rb.velocity = new Vector3((float)direction.normalized.x, bridgeDirection.y, (float)direction.normalized.y) * speed / 1.3f;
                    }
                    else if (onBridge && direction.y < 0.1f)
                    {
                        rb.velocity = new Vector3((float)direction.normalized.x, -bridgeDirection.y, (float)direction.normalized.y) * speed / 1.5f;
                    }
                    else
                    {
                        Vector3 newMovement = new Vector3(direction.normalized.x, rb.velocity.y, direction.normalized.y) * speed / 1.5f;
                        if (!isGround)
                        {
                            newMovement.y = -10f;
                        }
                        else
                        {
                            newMovement.y = 0f;
                        }
                        rb.velocity = newMovement;
                    }
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!isFalling)
            {
                ChangeAnim("idle");
            }
            joystick.transform.position += new Vector3(10000, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    protected override void OnNewStage(Stage stage)
    {
        base.OnNewStage(stage);


        maxPosY = transform.position.y;

    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("step"))
        {
            //Debug.Log("len cau thang");
            if (other.gameObject.GetComponent<Step>().materialType != this.materialType)
            {
                //Debug.Log("len cau thang");
                if (baloBrickObjectList.Count > 0 && other.gameObject.transform.TransformPoint(other.transform.localPosition).y > maxPosY)
                {
                    //Debug.Log("len cau thang");
                    StartCoroutine(other.gameObject.GetComponent<Step>().ChangeColorStep(materialType));
                    DropBrick();
                    maxPosY = other.gameObject.transform.TransformPoint(other.transform.localPosition).y;
                }
            }
            else
            {
                maxPosY = other.gameObject.transform.TransformPoint(other.transform.localPosition).y;
            }
        }
        if (other.gameObject.CompareTag("win"))
        {
            GameManager.Instance.isWin = true;
            UIManager.instance.HideJoystick();
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            ChangeAnim("win");
            //Debug.Log("win");
        }

    }

    private bool CheckGround()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, raycastLength))
        {
            return true;
        }
        else
        {
            return false;

        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.CompareTag("bridgeTrigger"))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
