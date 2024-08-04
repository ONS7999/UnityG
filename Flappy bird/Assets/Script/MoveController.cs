using UnityEngine;

public class MoveController : MonoBehaviour
{
    //상태
    Rigidbody2D rd;     //Rigidbody2D 컴포넌트를 연결해 둘 변수
    

    [SerializeField] float jumpForce = 250;     //점프 힘 변수
    [SerializeField] float rotSpeed = 30;           //z축 회전 속도 변수
    [SerializeField] float an = 55;         //각도 설정값
    float angle = 0;                                //회전 z축에 적용할 변수

    SpriteRenderer sr;          //새 이미지를 그려주는 SpriteRenderer 컴포넌트를 연결해 둘 변수

    bool isJump = false;        //점프 상태 판단 변수

    float waitTime = 0.5f;      //점프 후 원래 이미지로 변경되기까지의 대기 시간
    float t = 0;                        //대기 시간을 카운트 할 변수



    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        //같은 오브젝트에 있는 컴포넌트들 중 Rigidbody2D 컴포넌트가 있다면 가져옴

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 마우스 버튼을 누를 때, Jump 메소드 호출
        if (Input.GetMouseButtonDown(0)) Jump();

       // Debug.Log(rd.velocity);     //속도를 확인할 수 있음
 
        SetAngle();         //매 프레임마다 SetAngle 메소드 호출

        //점프 상태라면
        if (isJump)
        {
            t += Time.deltaTime;        //대기 체크 시간 증가
            if (t >= waitTime)              //체크 시간이 대기 시간을 지났다면
            {
                //원래 이미지로 변경
                sr.sprite = Resources.Load<Sprite>("AngryBirdNormal");
                isJump = false;             //점프가 아닌 상태로 변경
            }
        }
    }

    void Jump()
    {
        //오브젝트에 적용된 속도 초기화
        rd.velocity = Vector2.zero;     //new Vector2(0,0)

        angle = 55;

        rd.AddForce(new Vector2(0, jumpForce));
        //y축으로 jumpFoce 변수의 값만큼 밀어줌

        sr.sprite = Resources.Load<Sprite>("AngryBirdJump");
        //asset 폴더에 Resources 폴더가 있다면
        //Resources 폴더에 접근해서 해당 이름의 파일을 가져옴

        isJump = true;          //점프 상태로 변경
        t = 0;                        //체크 시간 초기화
    }

    void SetAngle()
    {
        angle -= Time.deltaTime * rotSpeed;     //회전 값 감소
        transform.rotation = Quaternion.Euler(0,0, angle);
    }

}
