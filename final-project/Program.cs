﻿using System;
using final_project.Services;
using final_project.Actors;
using final_project.Actions;
using System.Collections.Generic;

namespace final_project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();
            Actor actor = new Actor();
            // Bricks
            cast["bricks"] = new List<Actor>();

            for(int x = 10; x < Constants.MAX_X; x+=Constants.BRICK_WIDTH + Constants.BRICK_SPACE)
            {
                for(int y = 10; y <= 146; y+=Constants.BRICK_HEIGHT + Constants.BRICK_SPACE)
                {
                    cast["bricks"].Add(new Brick(x,y,Constants.IMAGE_BRICK3));
                }
            }
            

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // TODO: Add your ball here

            // The paddle
            cast["paddle"] = new List<Actor>();
            // TODO: Add your paddle here

            cast["scoreBoard"] = new List<Actor>();

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction(physicsService,audioService);
            script["update"].Add(handleOffScreenAction);
            
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService);
            script["update"].Add(handleCollisionsAction);

            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);
            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();
            audioService.StopAudio();
        }
    }
}
