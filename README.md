# TV18Team03
This repository is used for a development of a VR experience using Unity 2017.3 & Google VR SDK.

## Objective
The project is called Taller Vertical, and it is an activity sponsored by Google & powered by Wizeline. Moreover, it is hosted at Tec de Monterrey Campus Guadalajara in Mexico. The task is to develop in one week "something" using Virtual Reality or Augmented Reality focusing on one of the 17 UN Sustainable Development Goals.

## Sustainable Development Goal To Focus On

[![Foo](http://globaldaily.com/wp-content/themes/globaldaily/images/goals-1.gif "SDG #1 No Poverty")](https://sustainabledevelopment.un.org/sdg1)


End poverty in all its forms everywhere
In signing Agenda 2030, governments around the world committed to ending poverty in all its manifestations, including its most extreme forms, over the next 15 years.

## What are we doing?

Using Unity & Google VR SDK we are going to develop an interactive experience where the user dives into an immersive low-poly universe. The user has to survive just like people in extreme poverty conditions do. There is a narrator that guides you into your adventure, but be careful, as there are dangerous places where you might be stalked, and attacked. This experience tries to make people aware on the living conditions that people in extreme poverty face every day. Survive your way to your humble home, and take whatever resources you can gather for yourself or for other members of your family.

### How to initialize a project With Unity 2017.3 & Google VR SDK 1.120

- Download .unitypackage of Google VR SDK 1.120 from [GoogleVR](https://github.com/googlevr/gvr-unity-sdk) and import them into Unity project. 
- Open Unity>File>Build Settings and Select Android from the Platforms list. Click Switch Platform button.
- Open Player Settings from Build Settings, and open Other Settings. Change the package name to something not generic, and choose your minimum Android API.
- Open XR Settings in Player Settings, and enable Virtual Reality Supported. Add Cardboard SDK, or whatever device SDK you are willing to.
- Make sure that you specified your Android SDK, and Java JDK in Edit>Preferences>External Tools
- Your Main Camera is now VR usable, go ahead and attach the camera to an Empty Object called Player.
- Add a GvrReticlePointer as a child of your MainCamera.
- Add GvrEditorEmulator, and GvrEventSystem to your scene.
- You are now good to go.

## Audio

To avoid uploading .wav files to the Git repository, they are added to the .gitignore file. If .wav file are requested please, ask for them.

## Team
Our team is made up by 9 Computer Systems Engineering, and 7 Animation & Digital Arts Students

#### Computer Systems Engineers:
- Michelle Sagnelli
- Edgar Briceño
- Alejandro Carrillo
- Robert Morales
- Alejandro Sánchez
- Iván Moret
- Esaú Preciado
- Andrés Salas
- Juan Torres

#### Animation & Digital Arts Students:
- Abigail Sáenz
- Roberto Aramburu
- Pablo Cárdenas
- Nereida Citlali
- Hugo Quintero
- Mel Sánchez