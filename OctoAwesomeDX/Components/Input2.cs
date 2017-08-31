﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace OctoAwesome.Components
{
    public class Input2 : GameComponent
    {
        public bool Left { get; private set; }
        public bool Right { get; private set; }
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Interact { get; set; }

        public Input2(Game game) : base(game)
        {
        }
        public override void Update(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            Interact = gamePadState.Buttons.A == ButtonState.Pressed;
            Left = gamePadState.ThumbSticks.Left.X < -.5f;
            Right = gamePadState.ThumbSticks.Left.X > .5f;
            Down = gamePadState.ThumbSticks.Left.Y < -.5f;
            Up = gamePadState.ThumbSticks.Left.Y > .5f;

            KeyboardState keyBoardState = Keyboard.GetState();
            Interact |= keyBoardState.IsKeyDown(Keys.Space);
            Left |= keyBoardState.IsKeyDown(Keys.Left);
            Right |= keyBoardState.IsKeyDown(Keys.Right);
            Up |= keyBoardState.IsKeyDown(Keys.Up);
            Down |= keyBoardState.IsKeyDown(Keys.Down);
        }
    }
}
