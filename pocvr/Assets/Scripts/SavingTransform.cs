using UnityEngine;
using System.Collections;

public class SavingTransform
{

    public Vector3 Position { get; set; }
    public Vector3 Scale { get; set; }
    public Quaternion Rotation { get; set; }


    public SavingTransform()
    {

    }

    public SavingTransform(Transform other)
    {
        Position = new Vector3(other.position.x, other.position.y, other.position.z);
        Scale = new Vector3(other.localScale.x, other.localScale.y, other.localScale.z);
        Rotation = new Quaternion(other.rotation.x, other.rotation.y, other.rotation.z, other.rotation.w);
    }

    public void CopyTransform(SavingTransform other)
    {
        Position = new Vector3(other.Position.x, other.Position.y, other.Position.z);
        Scale = new Vector3(other.Scale.x, other.Scale.y, other.Scale.z);
        Rotation = new Quaternion(other.Rotation.x, other.Rotation.y, other.Rotation.z, other.Rotation.w);
    }

    public bool ChangeSavingTransform(Transform other)
    {
        return ChangeSavingTransform(new SavingTransform(other));
    }

    public bool ChangeSavingTransform(SavingTransform other)
    {
        if (!Equals(other))
        {
            CopyTransform(other);
            return true;
        }
        return false;
    }

    public override bool Equals(object obj)
    {
        bool isEquals = false;

        if (obj.GetType() == typeof(SavingTransform))
        {
            SavingTransform other = (SavingTransform)obj;

            if (Vector3.Equals(Position, other.Position)
                && Vector3.Equals(Scale, other.Scale)
                && Quaternion.Equals(Rotation, other.Rotation))
            {
                isEquals = true;
            }
        }

        return isEquals;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
