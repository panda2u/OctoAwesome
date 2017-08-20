﻿using OctoAwesome.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoAwesome.Model
{
    internal sealed class Player
    {
        private Input input;
        private Map map;

        public readonly float MAXSPEED = 4f;

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public float Radius { get; private set; }

        public float Angle { get; private set; }

        public PlayerState State { get; private set; }

        public Player(Input input, Map map)
        {
            this.input = input;
            this.map = map;
            Position = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
            Radius = .1f;
        }

        public void Update(TimeSpan frameTime)
        {
            Velocity = new Vector2(
                    (input.Left ? -1f : 0f) + (input.Right ? 1f : 0f),
                    (input.Up ? -1f : 0f) + (input.Down ? 1f : 0f)
                    );

            

            if (Velocity.Length() > 0f)
            {
                Velocity = Velocity.Normalized() * MAXSPEED;
                State = PlayerState.Walk;
                Angle = Velocity.Angle();
                //Position += (Velocity * MAXSPEED * (float)frameTime.TotalSeconds);
            }
            else
            {
                State = PlayerState.Idle;
            }
        }
    }

    public enum PlayerState
    {
        Idle,
        Walk
    }
}