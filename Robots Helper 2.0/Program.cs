using Robots_Helper_2._0;
using ClickableTransparentOverlay;
using ImGuiNET;
using Swed32;
using System.Numerics;
using SharpDX.DXGI;
using System.Reflection;
using Veldrid;
using static System.Net.Mime.MediaTypeNames;  



namespace RobotsHelper
{
    public class Program : Overlay
    {

        static Swed swed = new Swed("robots");
        static IntPtr moduleBase;
        Offsets offsets = new Offsets();
        Statics statics = new Statics();
        HashCodesEntity hashCodesEntity = new HashCodesEntity();
        HashCodesAnimMode hashCodesAnimMode = new HashCodesAnimMode();
        List<SavePoint> savePoints = new List<SavePoint>();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();//.Wait();

            Thread maineLogicThread = new Thread(program.MainLogic) { IsBackground = true };
            maineLogicThread.Start();
        }

        void MainLogic()
        {
            moduleBase = swed.GetModuleBase("robots.exe");

            statics.targetFPSAddress = moduleBase + 0x3AD258;

            statics.currentFPSAddress = moduleBase + 0x003BB514;

            statics.levelIndexAddress = moduleBase + 0x3BB514;

            statics.saveMenuAddress = 0x007BB4BC;

            while (true)
            {
                statics.rodneyStateAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.rodneyState);
                statics.currentState = swed.ReadInt(statics.rodneyStateAddress);

                statics.renderingModeAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyRenderMode;

                statics.posXAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyXPosition;
                statics.posZAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyZPosition;
                statics.posYAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyYPosition;
                statics.currentXPosition = swed.ReadFloat(statics.posXAddress);
                statics.currentZPosition = swed.ReadFloat(statics.posZAddress);
                statics.currentYPosition = swed.ReadFloat(statics.posYAddress);

                statics.rotXAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyXRotation;
                statics.rotZAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyZRotation;
                statics.rotYAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyYRotation;
                statics.currentXRotation = swed.ReadFloat(statics.rotXAddress);
                statics.currentZRotation = swed.ReadFloat(statics.rotZAddress);
                statics.currentYRotation = swed.ReadFloat(statics.rotYAddress);

                statics.scaleXAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyXScale;
                statics.scaleZAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyZScale;
                statics.scaleYAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyYScale;
                statics.currentXScale = swed.ReadFloat(statics.scaleXAddress);
                statics.currentZScale = swed.ReadFloat(statics.scaleZAddress);
                statics.currentYScale = swed.ReadFloat(statics.scaleYAddress);

                statics.colorRAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyR;
                statics.colorGAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyG;
                statics.colorBAddress = swed.ReadPointer(moduleBase, offsets.rodneyBaseAddress) + offsets.rodneyB;
                statics.currentR = swed.ReadFloat(statics.colorRAddress);
                statics.currentG = swed.ReadFloat(statics.colorGAddress);
                statics.currentB = swed.ReadFloat(statics.colorBAddress);

                statics.velZAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.rodneyZVel);
                statics.currentZVel = swed.ReadFloat(statics.velZAddress);

                statics.speedAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.rodneySpeed);
                statics.currentSpeed = swed.ReadFloat(statics.speedAddress);

                statics.staminaAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.rodneyStamina);
                statics.currentStamina = swed.ReadFloat(statics.staminaAddress);

                statics.healthAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.health);
                statics.currentHealth = swed.ReadFloat(statics.healthAddress);

                statics.scrapAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.scrap);
                statics.currentScrap = swed.ReadInt(statics.scrapAddress);

                statics.burningAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.burning);
                statics.currentBurning = swed.ReadFloat(statics.burningAddress);

                statics.weaponWheelSelectionAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.weaponWheelSelection);
                statics.currentWeaponWheelSelection = swed.ReadInt(statics.weaponWheelSelectionAddress);

                statics.camAttachedAddress = moduleBase + offsets.camAttachedStaticAddress;
                if (swed.ReadInt(statics.camAttachedAddress) == 1)
                {
                    statics.attached = true;
                }
                else if (swed.ReadInt(statics.camAttachedAddress) == 0)
                {
                    statics.attached = false;
                }

                statics.unlimitedHealthAddress = 0x007BB4AF;
                if (swed.ReadInt(statics.unlimitedHealthAddress) == 1)
                {
                    statics.unlimitedHealth = true;
                }
                else if (swed.ReadInt(statics.unlimitedHealthAddress) == 0)
                {
                    statics.unlimitedHealth = false;
                }

                statics.unlimitedScrapAddress = moduleBase + 0x3BB4AE;
                if (swed.ReadInt(statics.unlimitedScrapAddress) == 1)
                {
                    statics.unlimitedScrap = true;
                }
                else if (swed.ReadInt(statics.unlimitedScrapAddress) == 0)
                {
                    statics.unlimitedScrap = false;
                }

                statics.noHitStrangeModeAddress = 0x007BB4C7;
                if (swed.ReadInt(statics.noHitStrangeModeAddress) == 1)
                {
                    statics.strangeMode = true;
                }
                else if (swed.ReadInt(statics.noHitStrangeModeAddress) == 0)
                {
                    statics.strangeMode = false;
                }



                statics.rodneyHashEntityAddress = moduleBase + offsets.rodneyHashEntity;

                statics.rodneyAnimModeAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.rodneyAnimMode);
                statics.currentRodneyAnimMode = swed.ReadInt(statics.rodneyAnimModeAddress);
                statics.currentRodneyAnimModeHex= statics.currentRodneyAnimMode.ToString("X");



                statics.wrenchXPosAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.wrenchXPos);
                statics.wrenchZPosAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.wrenchZPos);
                statics.wrenchYPosAddress = ReadPointerChain(moduleBase, offsets.rodneyBaseAddress, offsets.wrenchYPos);
                statics.currentWrenchXPosition = swed.ReadFloat(statics.wrenchXPosAddress);
                statics.currentWrenchZPosition = swed.ReadFloat(statics.wrenchZPosAddress);
                statics.currentWrenchYPosition = swed.ReadFloat(statics.wrenchYPosAddress);



                statics.windowBufferXAddress = swed.ReadPointer(moduleBase, offsets.settingBaseAddress) + offsets.windowBufferX;
                statics.windowBufferYAddress = swed.ReadPointer(moduleBase, offsets.settingBaseAddress) + offsets.windowBufferY;
                statics.currentBufferXPosition = swed.ReadInt(statics.windowBufferXAddress);
                statics.currentBufferYPosition = swed.ReadInt(statics.windowBufferYAddress);

                statics.subitlesAddress = moduleBase + 0x3ACEAC;
                if (swed.ReadInt(statics.subitlesAddress) == 1)
                {
                    statics.showSubtitles = true;
                }
                else if (swed.ReadInt(statics.subitlesAddress) == 0)
                {
                    statics.showSubtitles = false;
                }
            }
        }

        public IntPtr ReadPointerChain(IntPtr moduleBase, int baseOffset, int[] offsets)
        {
            IntPtr currentAddress = IntPtr.Add(moduleBase, baseOffset);
            // Apply each offset in the chain by dereferencing the pointer at each step
            foreach (int offset in offsets)
            {
                // Read the pointer at the current address
                currentAddress = swed.ReadPointer(currentAddress);
                // Now add the current offset to the value (pointer) read from the currentAddress
                currentAddress = IntPtr.Add(currentAddress, offset);
            }
            return currentAddress;
        }

        protected override void Render()
        {
            ImGuiIOPtr io = ImGui.GetIO();
            ImGuiStylePtr style = ImGui.GetStyle();
            style.WindowBorderSize = 0.0f;
            style.WindowRounding = 5f;
            style.ChildBorderSize = 0f;
            style.ChildRounding = 5f;

            System.Numerics.Vector4 newColor = new System.Numerics.Vector4(0.2f, 0.2f, 0.2f, 1.0f);
            style.Colors[(int)ImGuiCol.WindowBg] = new System.Numerics.Vector4(0.05f, 0.05f, 0.05f, 0.98f);
            style.Colors[(int)ImGuiCol.TitleBg] = newColor;
            style.Colors[(int)ImGuiCol.TitleBgActive] = newColor;
            style.Colors[(int)ImGuiCol.Header] = newColor;
            style.Colors[(int)ImGuiCol.HeaderHovered] = newColor;
            style.Colors[(int)ImGuiCol.HeaderActive] = newColor;
            style.Colors[(int)ImGuiCol.Button] = new System.Numerics.Vector4(0.1f, 0.4f, 0.8f, 1.0f);
            //style.Colors[(int)ImGuiCol.ButtonHovered] = new System.Numerics.Vector4(0.3f, 0.35f, 0.4f, 1.0f); // Hovered state
            style.Colors[(int)ImGuiCol.ButtonActive] = new System.Numerics.Vector4(0.1f, 0.15f, 0.2f, 1.0f); // Active state
            style.Colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(1.1f, 0.15f, 0.2f, 1.0f);
            style.Colors[(int)ImGuiCol.Tab] = new System.Numerics.Vector4(0.1f, 0.15f, 0.2f, 1.0f);
            style.Colors[(int)ImGuiCol.TabActive] = newColor;
            style.Colors[(int)ImGuiCol.Separator] = newColor;


            ImGui.SetNextWindowSize(new Vector2(600, 750), ImGuiCond.Always);
            bool open = true;
            ImGui.Begin("Robots Helper 2.0", ref open, ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse);
            {
                // Set the size of the child windows
                float childWidth = ImGui.GetContentRegionAvail().X / 2 - 4.0f; // Divide the available width by 2 (minus some padding)
                float childHeight = 110.0f; // Set a fixed height

                ImGui.BeginChild("ChildGeneral1", new Vector2(childWidth, 80), true);
                {
                    ImGui.Text($"Location: {swed.ReadVec(statics.posXAddress)}");
                    ImGui.Text($"Rotation: {swed.ReadVec(statics.rotXAddress)}");
                    ImGui.Text($"Scale: {swed.ReadVec(statics.scaleXAddress)}");

                    ImGui.Text($"FPS: {swed.ReadInt(statics.currentFPSAddress)}");
                    ImGui.SameLine();
                    if (ImGui.Button("Remove FPS Limit"))
                    {
                        swed.Nop(statics.targetFPSAddress, 1);
                        swed.WriteInt(statics.targetFPSAddress, 60);
                    }
                }
                ImGui.EndChild();


                ImGui.SameLine();


                ImGui.BeginChild("ChildGeneral2", new Vector2(childWidth, 80), true);
                {
                    ImGui.Text($"Speed: {Math.Truncate(statics.currentSpeed * 10000) / 10000}");
                    ImGui.Text($"Stamina: {Math.Truncate(statics.currentStamina * 10000) / 10000}");
                    ImGui.Text("(Fatigue 0.0 -> 1.0)");
                    if (ImGui.Button("Max"))
                    {
                        swed.WriteFloat(statics.staminaAddress, 1);
                    }
                }
                ImGui.EndChild();


                if (ImGui.BeginTabBar("Tabs"))
                {
                    if (ImGui.BeginTabItem("General"))
                    {
                        ImGui.BeginChild("ChildLocation", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Location Tweaker");
                            if (ImGui.SliderFloat("X", ref statics.posXOffset, -0.05f, 0.05f))
                            {
                                swed.WriteFloat(statics.posXAddress, statics.currentXPosition + statics.posXOffset);
                            }
                            else
                            {
                                if (statics.posXOffset != 0)
                                {
                                    statics.posXOffset = 0;
                                }
                            }

                            if (ImGui.SliderFloat("Z", ref statics.posZOffset, -0.05f, 0.05f))
                            {
                                swed.WriteFloat(statics.posZAddress, statics.currentZPosition + statics.posZOffset);
                                swed.WriteFloat(statics.velZAddress, 1);
                            }
                            else
                            {
                                if (statics.posZOffset != 0)
                                {
                                    statics.posZOffset = 0;
                                }
                            }

                            if (ImGui.SliderFloat("Y", ref statics.posYOffset, -0.05f, 0.05f))
                            {
                                swed.WriteFloat(statics.posYAddress, statics.currentYPosition + statics.posYOffset);
                            }
                            else
                            {
                                if (statics.posYOffset != 0)
                                {
                                    statics.posYOffset = 0;
                                }
                            }
                        }
                        ImGui.EndChild();


                        ImGui.SameLine();


                        ImGui.BeginChild("ChildScale", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Scale");
                            if (ImGui.SliderFloat("X", ref statics.currentXScale, 1, 2))
                            {
                                swed.WriteFloat(statics.scaleXAddress, statics.currentXScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##4"))
                            {
                                swed.WriteFloat(statics.scaleXAddress, 1);
                                statics.currentXScale = 1;
                            }

                            if (ImGui.SliderFloat("Z", ref statics.currentZScale, 0, 2))
                            {
                                swed.WriteFloat(statics.scaleZAddress, statics.currentZScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##5"))
                            {
                                swed.WriteFloat(statics.scaleZAddress, 1);
                                statics.currentZScale = 1;
                            }

                            if (ImGui.SliderFloat("Y", ref statics.currentYScale, -2, 2))
                            {
                                swed.WriteFloat(statics.scaleYAddress, statics.currentYScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##6"))
                            {
                                swed.WriteFloat(statics.scaleYAddress, 1);
                                statics.currentYScale = 1;
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("I##2"))
                            {
                                swed.WriteFloat(statics.scaleYAddress, -1);
                                statics.currentYScale = -1;
                            }
                        }
                        ImGui.EndChild();


                        ImGui.BeginChild("ChildRotation", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Rotation");
                            if (ImGui.SliderFloat("X", ref statics.currentXRotation, -7, 7))
                            {
                                swed.WriteFloat(statics.rotXAddress, statics.currentXRotation);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##1"))
                            {
                                swed.WriteFloat(statics.rotXAddress, 0);
                                statics.currentXRotation = 0;
                            }

                            if (ImGui.SliderFloat("Z", ref statics.currentZRotation, -7, 7))
                            {
                                swed.WriteFloat(statics.rotZAddress, statics.currentZRotation);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##2"))
                            {
                                swed.WriteFloat(statics.rotZAddress, 0);
                                statics.currentZRotation = 0;
                            }

                            if (ImGui.SliderFloat("Y", ref statics.currentYRotation, -7, 7))
                            {
                                swed.WriteFloat(statics.rotYAddress, statics.currentYRotation);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##3"))
                            {
                                swed.WriteFloat(statics.rotYAddress, 0);
                                statics.currentYRotation = 0;
                            }
                        }
                        ImGui.EndChild();


                        ImGui.SameLine();


                        ImGui.BeginChild("ChildRGB", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("RGB");
                            if (ImGui.SliderFloat("R", ref statics.currentR, 0, 2))
                            {
                                swed.WriteFloat(statics.colorRAddress, statics.currentR);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##7"))
                            {
                                swed.WriteFloat(statics.colorRAddress, 1);
                                statics.currentR = 1;
                            }

                            if (ImGui.SliderFloat("G", ref statics.currentG, 0, 2))
                            {
                                swed.WriteFloat(statics.colorGAddress, statics.currentG);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##8"))
                            {
                                swed.WriteFloat(statics.colorGAddress, 1);
                                statics.currentG = 1;
                            }

                            if (ImGui.SliderFloat("B", ref statics.currentB, 0, 2))
                            {
                                swed.WriteFloat(statics.colorBAddress, statics.currentB);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##9"))
                            {
                                swed.WriteFloat(statics.colorBAddress, 1);
                                statics.currentB = 1;
                            }
                        }
                        ImGui.EndChild();


                        ImGui.BeginChild("ChildOther1", new Vector2(childWidth, childHeight), true);
                        {

                            if (ImGui.Button("Shrink Death"))
                            {
                                swed.WriteFloat(statics.scaleXAddress, 0.99f);
                            }

                            if (ImGui.Button("Teleport Up"))
                            {
                                swed.WriteFloat(statics.posZAddress, 40);
                            }

                            ImGui.SameLine();

                            if (ImGui.Button(statics.attached ? "Detach Camera" : "Attach Camera"))
                            {
                                statics.attached = !statics.attached;
                                swed.WriteInt(statics.camAttachedAddress, statics.attached ? 1 : 0);
                            }

                            if (ImGui.Button("Full Health"))
                            {
                                swed.WriteFloat(statics.healthAddress, 100);
                            }

                            ImGui.SameLine();

                            if (ImGui.Button("Take 1 Healthpoint"))
                            {
                                swed.WriteFloat(statics.healthAddress, (statics.currentHealth - 20));
                            }
                        }
                        ImGui.EndChild();


                        ImGui.SameLine();


                        ImGui.BeginChild("ChildOther2", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text($"Burning Ass Timer: {statics.currentBurning}");
                            if (ImGui.Button("Start Burn Ass"))
                            {
                                swed.WriteFloat(statics.burningAddress, 0.001f);
                            }

                            ImGui.SameLine();

                            if (ImGui.Button("Stop Burn Ass"))
                            {
                                swed.WriteFloat(statics.burningAddress, 0);
                            }

                            ImGui.Text("Current Scrap:");

                            if (ImGui.InputInt("", ref statics.currentScrap))
                            {
                                swed.WriteInt(statics.scrapAddress, statics.currentScrap);
                            }
                        }
                        ImGui.EndChild();


                        ImGui.BeginChild("childData1", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text($"Level Index: {swed.ReadInt(statics.levelIndexAddress)}");
                            ImGui.Text($"Rodney State: {statics.currentState}");
                            ImGui.Text($"Weapon Wheel Selection: {statics.currentWeaponWheelSelection}");
                        }
                        ImGui.EndChild();


                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Teleport"))
                    {
                        if (ImGui.Button("--Save Current Position--"))
                        {
                            SaveCurrentPosition();
                        }

                        foreach (var savePoint in savePoints)
                        {
                            if (ImGui.Button($"{savePoint.title}"))
                            {
                                TeleportToPosition(savePoint.position, savePoint.rotation);
                            }
                        }
                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Settings"))
                    {
                        ImGui.BeginChild("ChildWindowBuffer", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Window Buffer");
                            if (ImGui.InputInt("X", ref statics.currentBufferXPosition))
                            {
                                swed.WriteInt(statics.windowBufferXAddress, statics.currentBufferXPosition);
                            }
                            if (ImGui.InputInt("Y", ref statics.currentBufferYPosition))
                            {
                                swed.WriteInt(statics.windowBufferYAddress, statics.currentBufferYPosition);
                            }
                        }
                        ImGui.EndChild();


                        ImGui.BeginChild("childSettings", new Vector2(childWidth, childHeight), true);
                        {
                            if (ImGui.Button("Open Save Menu"))
                            {
                                swed.WriteInt(statics.saveMenuAddress, 1);
                            }

                            if (ImGui.Checkbox("Subtitles", ref statics.showSubtitles))
                            {
                                swed.WriteInt(statics.subitlesAddress, statics.showSubtitles ? 1 : 0);
                            }
                        }
                        ImGui.EndChild();

                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Wrench"))
                    {
                        ImGui.BeginChild("ChildLocation", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Location Tweaker");
                            if (ImGui.SliderFloat("X", ref statics.wrenchXPosOffset, -0.05f, 0.05f))
                            {
                                swed.WriteFloat(statics.wrenchXPosAddress, statics.currentWrenchXPosition + statics.wrenchXPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchXPosOffset != 0)
                                {
                                    statics.wrenchXPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##1"))
                            {
                                swed.WriteFloat(statics.wrenchXPosAddress, 0);
                                statics.currentWrenchXPosition = 0;
                            }

                            if (ImGui.SliderFloat("Z", ref statics.wrenchZPosOffset, -0.1f, 0.1f))
                            {
                                swed.WriteFloat(statics.wrenchZPosAddress, statics.currentWrenchZPosition + statics.wrenchZPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchZPosOffset != 0)
                                {
                                    statics.wrenchZPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##2"))
                            {
                                swed.WriteFloat(statics.wrenchZPosAddress, 0);
                                statics.currentWrenchZPosition = 0;
                            }

                            if (ImGui.SliderFloat("Y", ref statics.wrenchYPosOffset, -0.1f, 0.1f))
                            {
                                swed.WriteFloat(statics.wrenchYPosAddress, statics.currentWrenchYPosition + statics.wrenchYPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchYPosOffset != 0)
                                {
                                    statics.wrenchYPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##3"))
                            {
                                swed.WriteFloat(statics.wrenchYPosAddress, 0);
                                statics.currentWrenchYPosition = 0;
                            }
                        }
                        ImGui.EndChild();


                        ImGui.SameLine();


                        ImGui.BeginChild("ChildScale", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Scale");
                            if (ImGui.SliderFloat("X", ref statics.currentXScale, 1, 2))
                            {
                                swed.WriteFloat(statics.scaleXAddress, statics.currentXScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##4"))
                            {
                                swed.WriteFloat(statics.scaleXAddress, 1);
                                statics.currentXScale = 1;
                            }

                            if (ImGui.SliderFloat("Z", ref statics.currentZScale, 0, 2))
                            {
                                swed.WriteFloat(statics.scaleZAddress, statics.currentZScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##5"))
                            {
                                swed.WriteFloat(statics.scaleZAddress, 1);
                                statics.currentZScale = 1;
                            }

                            if (ImGui.SliderFloat("Y", ref statics.currentYScale, -2, 2))
                            {
                                swed.WriteFloat(statics.scaleYAddress, statics.currentYScale);
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##6"))
                            {
                                swed.WriteFloat(statics.scaleYAddress, 1);
                                statics.currentYScale = 1;
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("I##2"))
                            {
                                swed.WriteFloat(statics.scaleYAddress, -1);
                                statics.currentYScale = -1;
                            }
                        }
                        ImGui.EndChild();

                        ImGui.BeginChild("ChildRotation", new Vector2(childWidth, childHeight), true);
                        {
                            ImGui.Text("Rotation");
                            if (ImGui.SliderFloat("X", ref statics.wrenchXPosOffset, -0.05f, 0.05f))
                            {
                                swed.WriteFloat(statics.wrenchXPosAddress, statics.currentWrenchXPosition + statics.wrenchXPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchXPosOffset != 0)
                                {
                                    statics.wrenchXPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##1"))
                            {
                                swed.WriteFloat(statics.wrenchXPosAddress, 0);
                                statics.currentWrenchXPosition = 0;
                            }

                            if (ImGui.SliderFloat("Z", ref statics.wrenchZPosOffset, -0.1f, 0.1f))
                            {
                                swed.WriteFloat(statics.wrenchZPosAddress, statics.currentWrenchZPosition + statics.wrenchZPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchZPosOffset != 0)
                                {
                                    statics.wrenchZPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##2"))
                            {
                                swed.WriteFloat(statics.wrenchZPosAddress, 0);
                                statics.currentWrenchZPosition = 0;
                            }

                            if (ImGui.SliderFloat("Y", ref statics.wrenchYPosOffset, -0.1f, 0.1f))
                            {
                                swed.WriteFloat(statics.wrenchYPosAddress, statics.currentWrenchYPosition + statics.wrenchYPosOffset);
                            }
                            else
                            {
                                if (statics.wrenchYPosOffset != 0)
                                {
                                    statics.wrenchYPosOffset = 0;
                                }
                            }
                            ImGui.SameLine();
                            if (ImGui.Button("R##3"))
                            {
                                swed.WriteFloat(statics.wrenchYPosAddress, 0);
                                statics.currentWrenchYPosition = 0;
                            }
                        }
                        ImGui.EndChild();

                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Models"))
                    {
                        ImGui.Text("Change Player Into NPC / Enemy Model");

                        if (ImGui.BeginTable("##hashCodesTable", 5))
                        {
                            ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed);
                            ImGui.TableSetupColumn("Value", ImGuiTableColumnFlags.WidthFixed);
                            ImGui.TableSetupColumn("Type", ImGuiTableColumnFlags.WidthFixed);
                            ImGui.TableSetupColumn("Unused", ImGuiTableColumnFlags.WidthFixed);
                            ImGui.TableSetupColumn("Description", ImGuiTableColumnFlags.WidthFixed);
                            ImGui.TableHeadersRow();

                            Type hashCodesEntityType = hashCodesEntity.GetType();

                            foreach (FieldInfo field in hashCodesEntityType.GetFields())
                            {
                                HashCodeData data = (HashCodeData)field.GetValue(hashCodesEntity);

                                ImGui.TableNextColumn();
                                if (ImGui.Button(field.Name))
                                {
                                    swed.WriteInt(statics.rodneyHashEntityAddress, data.Value);
                                    swed.WriteVec(statics.scaleXAddress, new Vector3(0, 0, 0));
                                }

                                ImGui.TableNextColumn();
                                ImGui.Text("0x" + data.Value.ToString("X"));


                                // Set the text color for the "Type" column based on the data.Type
                                ImGui.TableNextColumn();
                                if (data.Type == EntityTypes.player)
                                {
                                    ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0.0f, 0.5f, 1.0f, 1.0f)); // Blue
                                }
                                else if (data.Type == EntityTypes.enemy)
                                {
                                    ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1.0f, 0.5f, 0.0f, 1.0f)); // Orange
                                }
                                else if (data.Type == EntityTypes.npc)
                                {
                                    ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(0.5f, 1.0f, 0.0f, 1.0f)); // Green
                                }

                                // Draw the "Type" text
                                ImGui.Text(data.Type);
                                // Only pop the style color if it was pushed, meaning data.Type matches one of the conditions
                                if (data.Type == EntityTypes.player || data.Type == EntityTypes.enemy || data.Type == EntityTypes.npc)
                                {
                                    ImGui.PopStyleColor();
                                }


                                ImGui.TableNextColumn();
                                ImGui.Text(data.IsUnused ? "  X" : "");

                                ImGui.TableNextColumn();
                                ImGui.Text(data.Description);
                            }
                        }

                        ImGui.EndTable();

                        ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Animations"))
                    {
                        ImGui.Text("Displays The Current Animation Of Rodney");

                        ImGui.Text($"Hex: {statics.currentRodneyAnimModeHex}");
                        ImGui.Text($"Rodney Anim Mode: {hashCodesAnimMode.GetDescriptionFromHex(statics.currentRodneyAnimMode)}");

                       ImGui.EndTabItem();
                    }

                    if (ImGui.BeginTabItem("Misc"))
                    {
                        if (ImGui.Checkbox("No Hit (Strange Mode)", ref statics.strangeMode))
                        {
                            swed.WriteInt(statics.noHitStrangeModeAddress, statics.strangeMode ? 1 : 0);
                        }

                        ImGui.Separator();

                        if (ImGui.Button("Regular"))
                        {
                            swed.WriteInt(statics.renderingModeAddress, 76);
                        }
                        ImGui.SameLine();
                        if (ImGui.Button("Wireframe"))
                        {
                            swed.WriteInt(statics.renderingModeAddress, 69);
                        }

                        if (ImGui.Button("Regular + Render Layer"))
                        {
                            swed.WriteInt(statics.renderingModeAddress, 84);
                        }
                        ImGui.SameLine();
                        if (ImGui.Button("Wireframe + Render Layer"))
                        {
                            swed.WriteInt(statics.renderingModeAddress, 221);
                        }

                        ImGui.Separator();

                        ImGui.Text("Cheat Codes");

                        if (ImGui.Checkbox("Unlimited Health", ref statics.unlimitedHealth))
                        {
                            swed.WriteInt(statics.unlimitedHealthAddress, statics.unlimitedHealth ? 1 : 0);
                        }
                        if (ImGui.Checkbox("Unlimited Scrap", ref statics.unlimitedScrap))
                        {
                            swed.WriteInt(statics.unlimitedScrapAddress, statics.unlimitedScrap ? 1 : 0);
                        }

                        ImGui.EndTabItem();
                    }
                }
                ImGui.EndTabBar();

                ImGui.End();
            }
            if (!open)
            {
                Environment.Exit(0);
            }
        }

        void SaveCurrentPosition()
        {
            string savePointTitle = "Save Point " + (savePoints.Count + 1);
            Vector3 currentPlayerPosition = GetCurrentPlayerPosition();
            float currentPlayerRotation = GetCurrentZPlayerRotation();
            SavePoint savePoint = new SavePoint { title = savePointTitle, position = currentPlayerPosition, rotation = currentPlayerRotation };
            savePoints.Add(savePoint);
        }

        void TeleportToPosition(Vector3 position, float rotation)
        {
            swed.WriteVec(statics.posXAddress, position);
            swed.WriteFloat(statics.rotZAddress, rotation);
        }

        Vector3 GetCurrentPlayerPosition()
        {
            return swed.ReadVec(statics.posXAddress);
        }

        float GetCurrentZPlayerRotation()
        {
            return swed.ReadFloat(statics.rotZAddress);
        }
    }
}