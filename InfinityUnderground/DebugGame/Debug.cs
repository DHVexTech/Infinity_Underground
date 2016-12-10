﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using InfinityUnderground.Camera;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Content;
using InfinityUnderground;

namespace InfinityUnderground.DebugGame
{
    class Debug : IEntity
    {
        private InfinityUnderground.Game1 _context;
        private readonly TimeSpan IntervalBetweenF10Menu;
        private readonly TimeSpan IntervalBetweenF11Menu;
        private TimeSpan LastActiveF10Menu;
        private TimeSpan LastActiveF11Menu;
        private SpriteFont font;
        public int MousePositionY;
        public int MousePositionX;
        CameraLoader _camera;

        /// <summary>
        /// Gets or sets a value indicating whether [debug state].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [debug state]; otherwise, <c>false</c>.
        /// </value>
        public bool DebugState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Debug"/> class.
        /// This class is used to print infos in screen. 
        /// Debug parameters is all parameters who have to be
        /// disable at final version of the game.
        /// </summary>
        /// <param name="context">The context.</param>
        public Debug(Game1 context, CameraLoader camera)
        {
            _camera = camera;
            _context = context;
            DebugState = false;

            IntervalBetweenF10Menu = TimeSpan.FromMilliseconds(200);
            IntervalBetweenF11Menu = TimeSpan.FromMilliseconds(1000);
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            font = _context.Content.Load<SpriteFont>("debug");
        }


        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            // DEBUG PARAMETERS
            _context.MapLoad.GetLayerCollide.IsVisible = false;
            _context.IsMouseVisible = true;
            _context.Window.AllowAltF4 = true;

            MouseState Mousstate = Mouse.GetState();
            MousePositionY = Mousstate.Y;
            MousePositionX = Mousstate.X;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F12) && LastActiveF10Menu + IntervalBetweenF10Menu < gameTime.TotalGameTime)
            {
                DebugState = !DebugState;
                LastActiveF10Menu = gameTime.TotalGameTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F11) && LastActiveF11Menu + IntervalBetweenF11Menu < gameTime.TotalGameTime)
            {
                _context.Graphics.ToggleFullScreen();
                LastActiveF11Menu = gameTime.TotalGameTime;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (DebugState)
            {
                spriteBatch.DrawString(font, $" Camera Vector Position: X: {_camera.GetCamera.Position.X} Y: {_camera.GetCamera.Position.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y), Color.White);
                spriteBatch.DrawString(font, $" Player Vector Position: X: {_context.Player.CTPlayer.PositionX} Y: {_context.Player.CTPlayer.PositionY}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 20), Color.White);
                spriteBatch.DrawString(font, $" Player Vector Position: X: {_context.WorldAPI.Player1PositionXInTile} Y: {_context.WorldAPI.Player1PositionYInTile}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 40), Color.White);
                spriteBatch.DrawString(font, $" Room Vector Position: X: {_context.WorldAPI.Level.GetRooms.PosCurrentRoom.X} Y: {_context.WorldAPI.Level.GetRooms.PosCurrentRoom.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 60), Color.White);
                spriteBatch.DrawString(font, $" Final Room Vector Position: X: {_context.WorldAPI.Level.GetRooms.RoomOut.X} Y: {_context.WorldAPI.Level.GetRooms.RoomOut.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 80), Color.White);
                spriteBatch.DrawString(font, $" Level : {_context.WorldAPI.Level.GetCurrentlevel}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 100), Color.White);
                spriteBatch.DrawString(font, $" Bat LifePoint : {_context.WorldAPI.ListOfPlayer[0].GetCharacterType.LifePoint}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 120), Color.White);
           }
        }

        /// <summary>
        /// Determines whether [is final room].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is final room]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFinalRoom() => (_context.WorldAPI.Level.GetRooms.PosCurrentRoom == _context.WorldAPI.Level.GetRooms.RoomOut);

        /// <summary>
        /// Tests the switch room.
        /// </summary>
        /// <returns></returns>
        public bool TestSwitchRoom() => (_context.WorldAPI.Level.GetRooms.PlayerInTheDoor() != null);

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
        }
    }
}