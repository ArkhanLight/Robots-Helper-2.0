using SixLabors.ImageSharp.Metadata.Profiles.Iptc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots_Helper_2._0
{
    public class Statics
    {
        public IntPtr rodneyStateAddress;
        public int currentState;

        public IntPtr renderingModeAddress;

        public  IntPtr posXAddress;
        public  IntPtr posZAddress;
        public  IntPtr posYAddress;
        public float currentXPosition;
        public float currentZPosition;
        public float currentYPosition;
        public float posXOffset = 0.0f;
        public float posZOffset = 0.0f;
        public float posYOffset = 0.0f;

        public IntPtr rotXAddress;
        public IntPtr rotZAddress;
        public IntPtr rotYAddress;
        public float currentXRotation;
        public float currentZRotation;
        public float currentYRotation;

        public IntPtr scaleXAddress;
        public IntPtr scaleZAddress;
        public IntPtr scaleYAddress;
        public float currentXScale;
        public float currentZScale;
        public float currentYScale;

        public IntPtr colorRAddress;
        public IntPtr colorGAddress;
        public IntPtr colorBAddress;
        public float currentR;
        public float currentG;
        public float currentB;

        public IntPtr velZAddress;
        public float currentZVel;

        public IntPtr speedAddress;
        public float currentSpeed;

        public IntPtr staminaAddress;
        public float currentStamina;

        public IntPtr healthAddress;
        public float currentHealth;

        public IntPtr scrapAddress;
        public int currentScrap;

        public IntPtr camAttachedAddress;
        public bool attached = true;

        public IntPtr burningAddress;
        public float currentBurning;

        public IntPtr weaponWheelSelectionAddress;
        public int currentWeaponWheelSelection;



        public IntPtr noHitStrangeModeAddress;
        public bool strangeMode = true;

        public IntPtr unlimitedHealthAddress;
        public bool unlimitedHealth = true;

        public IntPtr unlimitedScrapAddress;
        public bool unlimitedScrap = true;



        public IntPtr targetFPSAddress;
        public IntPtr currentFPSAddress;

        public IntPtr levelIndexAddress;



        public IntPtr rodneyHashEntityAddress;

        public IntPtr rodneyAnimModeAddress;
        public int currentRodneyAnimMode;
        public string? currentRodneyAnimModeHex;



        public IntPtr wrenchXPosAddress;
        public IntPtr wrenchZPosAddress;
        public IntPtr wrenchYPosAddress;
        public float currentWrenchXPosition;
        public float currentWrenchZPosition;
        public float currentWrenchYPosition;
        public float wrenchXPosOffset = 0.0f;
        public float wrenchZPosOffset = 0.0f;
        public float wrenchYPosOffset = 0.0f;

        public IntPtr wrenchRotationXAddress;
        public IntPtr wrenchRotationZAddress;
        public IntPtr wrenchRotationYAddress;
        public float currentWrenchXRotation;
        public float currentWrenchZRotation;
        public float currentWrenchYRotation;

        public IntPtr wrenchScaleXAddress;
        public IntPtr wrenchScaleZAddress;
        public IntPtr wrenchScaleYAddress;
        public float currentWrenchXScale;
        public float currentWrenchYScale;
        public float currentWrenchZScale;



        public IntPtr windowBufferXAddress;
        public IntPtr windowBufferYAddress;
        public int currentBufferXPosition;
        public int currentBufferYPosition;

        public IntPtr saveMenuAddress;

        public IntPtr subitlesAddress;
        public bool showSubtitles = true;
    }
}
