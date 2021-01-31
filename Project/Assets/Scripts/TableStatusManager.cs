using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStatusManager : MonoBehaviour
{

    public Material no_status_mat;

    bool is_waiting_water;
    bool is_waiting_waiter;


    enum statuses
    {
        EMPTY,
        WAITING_FOR_ORDER,
        WAITING_FOR_DISHES,
        EATING
    }

    statuses status;

    void Start()
    {
        status = statuses.EMPTY;
    }
    

    void Update()
    {
        switch (status)
        {
            case statuses.EMPTY:
                GetComponent<MeshRenderer>().material = no_status_mat;
                break;
            default:
                break;
        }
    }

    void set_is_waiting_water(bool is_waiting_water)
    {
        this.is_waiting_water = is_waiting_water;
    }

    void set_is_waiting_waiter(bool is_waiting_waiter)
    {
        this.is_waiting_waiter = is_waiting_waiter;
    }

    void set_status(int sta)
    {
        switch (sta)
        {
            case 0: //Table is empty
                status = statuses.EMPTY;
                break;
            case 1: //Table is occupied and waiting for order
                status = statuses.WAITING_FOR_ORDER;
                break;
            case 2: //Table is occupied and waiting for order
                status = statuses.WAITING_FOR_DISHES;
                break;
            case 3: //Table is occupied and waiting for order
                status = statuses.EATING;
                break;
        }
    }


}
