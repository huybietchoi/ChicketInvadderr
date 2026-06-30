using UnityEngine;
using UnityEngine.InputSystem;

public class ShipScript : MonoBehaviour
{
    [SerializeField] private float Speed = 5f; // Đặt sẵn giá trị mặc định là 5
    [SerializeField] private GameObject[] BulletList;
    [SerializeField] private int CurrentTierBullet;

    [SerializeField] private GameObject Boom;
    void Start()
    {
       
    }

    void Update()
    {
        Move();        
        Fire();
    }
    void Move()
    {
        //DI CHUYỂN
        // 2. Lấy dữ liệu bấm phím Mũi tên  từ Bàn phím (Keyboard)
        float x = 0;
        float y = 0;

        if (Keyboard.current != null)
        {
            // Kiểm tra phím Ngang (A/D hoặc Mũi tên Trái/Phải)
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;

            // Kiểm tra phím Dọc (W/S hoặc Mũi tên Lên/Xuống)
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) y = -1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) y = 1f;
        }

        // 3. Giữ nguyên logic di chuyển mượt 
        Vector3 direction = new Vector3(x, y, 0);
        transform.position += direction.normalized * Time.deltaTime * Speed;
    }

    void Fire()
    {
        //nhấn chuột trái mới bắn 
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(BulletList[CurrentTierBullet], transform.position, Quaternion.identity);
            //BulletList[CurrentTierBullet] danh sách đạn
            //transform.position            vị trí tạo
            //Quaternion.identity           góc xoay ( mặc định = 0 )
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
            Destroy(gameObject);    
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded) //nếu obj thay đổi thì Boom
        {
          var boom =  Instantiate(Boom, transform.position, Quaternion.identity);
            Destroy(boom,1f);
        }
    }



}