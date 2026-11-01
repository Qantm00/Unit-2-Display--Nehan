# Interactive lab — Unity Unit 2

Practice controls and connected events before designing your own levels.

1. Extract the ZIP to a short local folder such as C:/VGD/interactive-lab. Keep the original ZIP as a backup.
2. In Unity Hub, Add project from disk. Select the folder with Assets, Packages and ProjectSettings. Open with Unity 6000.6.0f1. First import needs package access: URP17.6, Input System1.20, ProBuilder6.1.2.
3. Open Assets/Scenes/InteractiveLab.unity. Enter Play and click Game.
4. WASD moves relative to the camera; Space jumps; hold right mouse and move it to orbit the camera. R reloads the scene. Falling off returns you to the first start. Stop Play before saving changes.

The first platform contains a touch panel at x=-3,z=3 that changes colour on solid contact, a cyan trigger at x=3,z=3 that opens the door and starts the display, a timer lamp, and a green finish trigger at z=10. Walk through the green finish to reach the second practice platform. Its blue return gate teleports you back. These two short stations are not an assessed level design.

Try Player > Unit Two Walker > Move Speed: 4 versus 2. Try Systems/Timer > Interval: 2 versus 1. Restore one before comparing another. Expected: movement slows or lamp switches more often.

Scripts are supplied and commented. You may tune fields and connect Inspector events without writing a controller. CharacterController contact uses OnControllerColliderHit, not a Rigidbody OnCollisionEnter. Trigger volumes have Is Trigger on and a kinematic Rigidbody; the player has CharacterController. Do not add a Rigidbody to the player.

If movement fails, click Game, check the Console first red error and confirm Input System (New) is active. If a response fails, inspect the named target in the event field. For the finish, check Teleport To is assigned and the destination is outside a trigger. R needs the supplied InteractiveLab scene in File > Build Profiles > Scene List.

Keep .meta files when copying assets. Keep Assets, Packages and ProjectSettings for sharing. Library, Temp, Logs and obj are regenerated. Check an extracted ZIP or fresh clone opens before submission.

All scripts and simple assets in this lab are original course support, MIT licensed. This is a desktop keyboard/mouse teaching controller, not a complete character package. It deliberately omits animation, gamepad bindings and moving-platform carrying. Native validation evidence is held in the course authoring reviews.
