using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct BallSystem : ISystem
{
    //This function will be called in the beginning when the system is initialized.
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<BallData>(); //Ensures that the update function that is below, only runs when there is a BallData component.
        //This doesn't do much here but if your component comes at later points of the game, this will prevent errors.
    }

    public void OnUpdate(ref SystemState state)
    {
        BallJob job = new BallJob
        {
            DeltaTime = SystemAPI.Time.DeltaTime //You can't access delta time directly.
        };

        job.ScheduleParallel();
    }

    public partial struct BallJob : IJobEntity
    {
        public float DeltaTime;
        
        //The parameters are totally custom, so it can be anything you want to modify.
        public void Execute(ref BallData ballData, ref LocalTransform transform)
        {
            //This is called in every frame
            transform = transform.Translate(ballData.direction * ballData.speed * DeltaTime);
        }
    }
}
