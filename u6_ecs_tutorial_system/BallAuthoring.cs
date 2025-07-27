using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

//This is a middleman baker script that will bake the ball data script to our ball entity.

public class BallAuthoring : MonoBehaviour
{
    public float speed;
    public float3 direction;
    
    //This class will only be used by our authoring class so it doesnt have to be outside.
    private class Baker : Baker<BallAuthoring>
    {
        public override void Bake(BallAuthoring authoring)
        {
            //Will get our entity and attach ball data to it.
            //Will pas the data that is defined in ball authoring to the ball data when attaching.
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BallData
            {
                speed = authoring.speed,
                direction = authoring.direction,
            });
        }
    }
}
