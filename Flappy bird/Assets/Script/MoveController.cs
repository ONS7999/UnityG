using UnityEngine;

public class MoveController : MonoBehaviour
{
    //����
    Rigidbody2D rd;     //Rigidbody2D ������Ʈ�� ������ �� ����
    

    [SerializeField] float jumpForce = 250;     //���� �� ����
    [SerializeField] float rotSpeed = 30;           //z�� ȸ�� �ӵ� ����
    [SerializeField] float an = 55;         //���� ������
    float angle = 0;                                //ȸ�� z�࿡ ������ ����

    SpriteRenderer sr;          //�� �̹����� �׷��ִ� SpriteRenderer ������Ʈ�� ������ �� ����

    bool isJump = false;        //���� ���� �Ǵ� ����

    float waitTime = 0.5f;      //���� �� ���� �̹����� ����Ǳ������ ��� �ð�
    float t = 0;                        //��� �ð��� ī��Ʈ �� ����



    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        //���� ������Ʈ�� �ִ� ������Ʈ�� �� Rigidbody2D ������Ʈ�� �ִٸ� ������

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���콺 ��ư�� ���� ��, Jump �޼ҵ� ȣ��
        if (Input.GetMouseButtonDown(0)) Jump();

       // Debug.Log(rd.velocity);     //�ӵ��� Ȯ���� �� ����
 
        SetAngle();         //�� �����Ӹ��� SetAngle �޼ҵ� ȣ��

        //���� ���¶��
        if (isJump)
        {
            t += Time.deltaTime;        //��� üũ �ð� ����
            if (t >= waitTime)              //üũ �ð��� ��� �ð��� �����ٸ�
            {
                //���� �̹����� ����
                sr.sprite = Resources.Load<Sprite>("AngryBirdNormal");
                isJump = false;             //������ �ƴ� ���·� ����
            }
        }
    }

    void Jump()
    {
        //������Ʈ�� ����� �ӵ� �ʱ�ȭ
        rd.velocity = Vector2.zero;     //new Vector2(0,0)

        angle = 55;

        rd.AddForce(new Vector2(0, jumpForce));
        //y������ jumpFoce ������ ����ŭ �о���

        sr.sprite = Resources.Load<Sprite>("AngryBirdJump");
        //asset ������ Resources ������ �ִٸ�
        //Resources ������ �����ؼ� �ش� �̸��� ������ ������

        isJump = true;          //���� ���·� ����
        t = 0;                        //üũ �ð� �ʱ�ȭ
    }

    void SetAngle()
    {
        angle -= Time.deltaTime * rotSpeed;     //ȸ�� �� ����
        transform.rotation = Quaternion.Euler(0,0, angle);
    }

}
