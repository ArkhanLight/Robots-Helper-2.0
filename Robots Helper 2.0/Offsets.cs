using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Robots_Helper_2._0
{
    public class Offsets
    {
        public int rodneyBaseAddress = 0x3BA7C0;

        public int[] rodneyState = { 0x8, 0x114, 0x10, 0x34, 0x8 };

        public int rodneyRenderMode = 0x64;

        public int rodneyXPosition = 0xD0;
        public int rodneyZPosition = 0xD4;
        public int rodneyYPosition = 0xD8;

        public int rodneyXRotation = 0xE0;
        public int rodneyZRotation = 0xE4;
        public int rodneyYRotation = 0xE8;

        public int rodneyXScale = 0xF0;
        public int rodneyZScale = 0xF4;
        public int rodneyYScale = 0xF8;

        public int rodneyR = 0x4C;
        public int rodneyG = 0x50;
        public int rodneyB = 0x54;

        public int[] rodneyZVel = { 0x118, 0x40, 0x124 };

        public int[] rodneySpeed = { 0x5C, 0x4E0 };

        public int[] rodneyStamina = { 0x5C, 0x4F4 };

        public int[] health = { 0x5C, 0x2F8 };

        public int[] scrap = { 0x5C, 0x40C, 0x4 };

        public int camAttachedStaticAddress = 0x3BAF54;

        public int[] burning = { 0x5C, 0x64C };

        public int[] weaponWheelSelection = { 0x5C, 0x540 };



        public int rodneyHashEntity = 0x3AC908;

        public int[] rodneyAnimMode = { 0x5C, 0x3EC };



        public int[] wrenchXPos = { 0x5C, 0x4CC, 0xD4 };
        public int[] wrenchZPos = { 0x5C, 0x4CC, 0xD0 };
        public int[] wrenchYPos = { 0x5C, 0x4CC, 0xD8 };

        public int[] wrenchXRot = { 0x5C, 0x4CC, 0xE4 };
        public int[] wrenchZRot = { 0x5C, 0x4CC, 0xE0 };
        public int[] wrenchYRot = { 0x5C, 0x4CC, 0xE8 };

        public int[] wrenchXScale = { 0x5C, 0x4CC, 0xF4 };
        public int[] wrenchZScale = { 0x5C, 0x4CC, 0xf0 };
        public int[] wrenchYScale = { 0x5C, 0x4CC, 0xF8 };



        public int settingBaseAddress = 0x3BB4E8;

        public int windowBufferX = 0x20;
        public int windowBufferY = 0x24;
    }
}


