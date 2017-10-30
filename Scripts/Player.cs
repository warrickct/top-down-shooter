﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]   //forces the player controller script to be added to an an object when player.cs added.
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity {

    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

	protected override void Start () {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
	}

	void Update () {

        //This is my movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        //this is my look input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        //weapon input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}
