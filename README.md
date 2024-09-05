# Better Desktop Interaction System For VRChat

Better than [`Interact()`](https://creators.vrchat.com/worlds/udon/graph/event-nodes#interact).

## Feature

- Support multiple input type
  - Mouse Left Click
  - Mouse Right Click
  - Mouse Middle Click
  - Mouse Scroll Up
  - Mouse Scroll Down
- A Nice-looking tooltip ui
- Custom Event name

## Usage

1. Install this package.
2. Drop `Prefab/DesktopInteractionSystem.prefab` into your scene.
3. Select a Layout for DesktopInteractionSystem in `DesktopInteractionPlayerController`.
4. Add `DesktopInteractionControl` script into your GameObject and create a Collider in it.
5. Set the GameObject's layer to the layer which use by the DesktopInteractionSystem.
6. Setup the `DesktopInteractionControl` script.
7. Done.
