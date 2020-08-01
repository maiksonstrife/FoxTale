using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public enum Orientation { Area_A, AreaAtoB, Area_B, Area_B2, Area_C, Area_D, Area_E, Area_F, Area_DtoF }
    public Orientation orientation;


    public static bool changeDirection(Orientation orientation)
    {
        if (orientation == Orientation.Area_A)
        {
            float max_X = -74f;
            float max_Y = 8.5f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                //Debug.Log("returned false");

                return false;
            }
            //(upper right)
            CameraController.instance.max_X = -75.2f;
            CameraController.instance.max_Y = 8.5f;
            //(lower left)
            CameraController.instance.min_X = -328.61f;
            CameraController.instance.min_Y = -14.28f;
            return true;
        }

        if (orientation == Orientation.AreaAtoB)
        {
            float max_X = -52.4f;
            float max_Y = 2.8f;

            //Is the same area?
            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }

            //(upper right)
            CameraController.instance.max_X = -52.4f;
            CameraController.instance.max_Y = 2.8f;
            //(lower left)
            CameraController.instance.min_X = -57.3f;
            CameraController.instance.min_Y = 2.8f;
            return true;
        }


        if (orientation == Orientation.Area_B)
        {
            float max_X = 15.8f;
            float max_Y = 9.5f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
                //(upper right)
                CameraController.instance.max_X = 15.8f;
                CameraController.instance.max_Y = 9.5f;
                //(lower left)
                CameraController.instance.min_X = -34.3f;
                CameraController.instance.min_Y = -6.3f;
                return true;
        }

        if (orientation == Orientation.Area_B2)
        {
            float max_X = -52.19f;
            float max_Y = -11.38f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
                //(upper right)
                CameraController.instance.max_X = -52.19f;
                CameraController.instance.max_Y = -11.38f;
                //(lower left)
                CameraController.instance.min_X = -70.34f;
                CameraController.instance.min_Y = -14.29f;
            return true;
        }

        if (orientation == Orientation.Area_C)
        {
            float max_X = 42.34f;
            float max_Y = 7.14f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }

                //(upper right)
                CameraController.instance.max_X = 42.34f;
                CameraController.instance.max_Y = 7.14f;
                //(lower left)
                CameraController.instance.min_X = 33.7f;
                CameraController.instance.min_Y = -4.1f;
                return true;
        }

        if (orientation == Orientation.Area_D)
        {
            float max_X = 61.68f;
            float max_Y = 7.2f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
                //(upper right)
                CameraController.instance.max_X = 61.68f;
                CameraController.instance.max_Y = 7.2f;
                //(lower left)
                CameraController.instance.min_X = 61.68f;
                CameraController.instance.min_Y = -2.12f;
                return true;
        }

        if (orientation == Orientation.Area_E)
        {
            float max_X = 95.85f;
            float max_Y = -3.4f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
                //(upper right)
                CameraController.instance.max_X = 95.85f;
                CameraController.instance.max_Y = -3.4f;
                //(lower left)
                CameraController.instance.min_X = 80.9f;
                CameraController.instance.min_Y = -6.4f;
                return true;
        }

        if (orientation == Orientation.Area_F)
        {
            float max_X = 156f;
            float max_Y = 12.73f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
            //(upper right)
            CameraController.instance.max_X = 156f;
            CameraController.instance.max_Y = 12.73f;
            //(lower left)
            CameraController.instance.min_X = 114.06f;
            CameraController.instance.min_Y = -3.31f;
            return true;
        }

        if (orientation == Orientation.Area_F)
        {
            float max_X = 156f;
            float max_Y = 12.73f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
            //(upper right)
            CameraController.instance.max_X = 156f;
            CameraController.instance.max_Y = 12.73f;
            //(lower left)
            CameraController.instance.min_X = 114.06f;
            CameraController.instance.min_Y = -3.31f;
            return true;
        }

        if (orientation == Orientation.Area_DtoF)
        {
            float max_X = 97.03f;
            float max_Y = 7.61f;

            if (max_X == CameraController.instance.max_X || max_Y == CameraController.instance.max_Y)
            {
                return false;
            }
            //(upper right)
            CameraController.instance.max_X = 97.03f;
            CameraController.instance.max_Y = 7.61f;
            //(lower left)
            CameraController.instance.min_X = 79.87f;
            CameraController.instance.min_Y = 7.61f;
            return true;
        }


        //if there's none
        return false;
    }
}
