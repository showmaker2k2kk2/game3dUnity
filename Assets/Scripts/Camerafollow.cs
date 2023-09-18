using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;  // Nhân vật cần theo dõi
    public float moveSpeed = 5f;  // Tốc độ di chuyển camera
    public float height= 20f;
    public float minX = -10f;  // Giới hạn tọa độ x tối thiểu
    public float maxX = 10f;   // Giới hạn tọa độ x tối đa

    void LateUpdate()
    {
        if (target == null)
            return;

        // Lấy vị trí mới mà camera cần di chuyển tới
        //Vector3 desiredPosition = target.position;1
        //Vector3 desiredPosition = target.position-transform.position;  2
         Vector3 desiredPosition =  new Vector3(target.position.x,target.position.y+height,target.position.z);
        /*desiredPosition.z = transform.position.z; */ // Giữ cố định toạ độ z

        // Di chuyển mượt camera tới vị trí mới
        transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
        // Lấy tọa độ hiện tại của camera
        Vector3 currentPosition = transform.position;

        // Giới hạn tọa độ x trong phạm vi (minX, maxX)
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Cập nhật lại tọa độ của camera
        transform.position = currentPosition;

    }
    #region
    //public Transform target;  // Nhân vật cần theo dõi
    //public float rotationSpeed = 5f;  // Tốc độ xoay camera

    //void LateUpdate()
    //{
    //    if (target == null)
    //        return;

    //    // Lấy hướng vector từ camera tới nhân vật
    //    Vector3 direction = target.position - transform.position;
    //    //Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

    //    // Xoay mượt camera tới hướng mới
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    //}
    #endregion
    #region
    //public Transform target;  // Nhân vật cần theo dõi
    //public float smoothSpeed = 0.125f;  // Độ mượt của di chuyển camera
    //public float height = 20f;

    //void LateUpdate()
    //{
    //    if (target == null)
    //        return;

    //    Vector3 desiredPosition =  new Vector3(target.position.x,target.position.y+height,target.position.z);
    //    desiredPosition.z = transform.position.z;  // Giữ cố định toạ độ z

    //    // Di chuyển camera một cách mượt tới vị trí mong muốn
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}
    #endregion
}