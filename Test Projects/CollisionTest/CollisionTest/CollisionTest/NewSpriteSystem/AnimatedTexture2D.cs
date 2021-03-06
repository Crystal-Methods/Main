﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionTest.NewSpriteSystem
{
    public struct AnimatedTexture2D
    {
        private readonly Texture2D _sheet;
        private readonly Dictionary<string, AnimationCycle> _animations;
        private AnimationCycle _currentAnimation;
        private string _currentAnimationName;

        public Texture2D Sheet { get { return _sheet; } }

        public float Height { get { return _currentAnimation.FrameHeight; } }
        public float Width { get { return _currentAnimation.FrameWidth; } }

        // The number of the current frame
        public int Frame
        {
            get { return _currentAnimation.CurrentFrame; }
            set { _currentAnimation.CurrentFrame = value % _currentAnimation.FrameCount; }
        }

        public AnimatedTexture2D(Texture2D sheet)
        {
            _sheet = sheet;
            _currentAnimationName = "default";
            _currentAnimation = new AnimationCycle
            {
                CurrentFrame = 0,
                FrameCount = 1,
                FrameHeight = _sheet.Height,
                FrameWidth = _sheet.Width,
                StartPosX = 0,
                StartPosY = 0
            };
            _animations = new Dictionary<string, AnimationCycle> {{_currentAnimationName, _currentAnimation}};
        }

        // Add an animation cycle
        public void AddAnimation(string name, int startPosX, int startPosY, int frameWidth, int frameHeight, int frameCount)
        {
            var newAni = new AnimationCycle
            {
                StartPosX = startPosX,
                StartPosY = startPosY,
                FrameWidth = frameWidth,
                FrameHeight = frameHeight,
                FrameCount = frameCount,
                CurrentFrame = 0
            };
            _animations.Add(name, newAni);
        }

        // Set the current animation to play
        public void SetAnimation(string name)
        {
            if (name.Equals(_currentAnimationName)) return;
            _currentAnimationName = name;
            _currentAnimation = _animations[name];
            _currentAnimation.CurrentFrame = 0;
        }

        public Rectangle CurrentFrame
        {
            get
            {
                return
                    new Rectangle(
                        _currentAnimation.StartPosX + (_currentAnimation.FrameWidth*_currentAnimation.CurrentFrame),
                        _currentAnimation.StartPosY, _currentAnimation.FrameWidth, _currentAnimation.FrameHeight);
            }
        }

        // private class for storing animation cyles
        private struct AnimationCycle
        {
            public int StartPosX { get; set; } // X position on the sheet where the loop begins
            public int StartPosY { get; set; } // Y position on the sheet where the loop begins
            public int FrameWidth { get; set; } // Width of each animation frame
            public int FrameHeight { get; set; } // Height of each animation frame
            public int FrameCount { get; set; } // Total number of frames in the animation
            public int CurrentFrame { get; set; } // The current frame this animation displays
        }

    }
}
