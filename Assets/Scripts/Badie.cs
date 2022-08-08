using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Badie : Target
{
    //ENCAPSULATION, POLYMPORHISM
    override public int pointValue
    {
        get
        {
            return m_pointValue;
        }
        set
        {
            //Baddies don't give points
            if (value <= 0)
            {
                m_pointValue = value;
            }
        }
    }
}
