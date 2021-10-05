﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEH.Entities;
using OpenTK;
namespace GameDLL
{
  public  class Cube:Entity
    {
        public Cube() : base("cube")
        {
            Random random = new Random();
            int size = random.Next(1, 4);
            //  ScaleEntity = new Vector3(random.Next(1, 4), random.Next(1, 4), random.Next(1, 4));
            ScaleEntity = Vector3.Zero;
            PositionEntity = new Vector3(random.Next(-10,10),-100, random.Next(-10, 10));
      //     RotateEntity = new Vector3(random.Next(0, 90), random.Next(0, 90), random.Next(0, 90));
            CollisionComponent.IsEnabled = true;
            PhysicsComponent.IsEnabled = true;
          
        }
    }
}
