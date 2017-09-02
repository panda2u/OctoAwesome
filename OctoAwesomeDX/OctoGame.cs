﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using OctoAwesome.Components;
using OctoAwesome.Rendering;
using System;

namespace OctoAwesomeDX
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OctoGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        CameraComponent camera;
        RenderComponent render;
        InputComponent input;
        WorldComponent world;
        Render3DComponent render3d;

        public OctoGame() : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "OctoAwesome";
            //this.Window.IsBorderless = true;
            //graphics.IsFullScreen = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            this.IsMouseVisible = true;

            input = new InputComponent(this);
            input.UpdateOrder = 1;
            Components.Add(input);

            world = new WorldComponent(this, input);
            world.UpdateOrder = 2;
            Components.Add(world);
            
            camera = new CameraComponent(this, world, input);
            camera.UpdateOrder = 3;
            Components.Add(camera);

            render3d = new Render3DComponent(this, world);
            render3d.DrawOrder = 1;
            Components.Add(render3d);
        }
    }
}
