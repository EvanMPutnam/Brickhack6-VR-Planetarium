
# Virtual Reality Planetarium
## Inspiration
In Rochester it is incredibly difficult for astronomy classes, amateur astronomers, etc to go out observing the night sky.  The weather in Rochester, as well as light pollution from the city, creates an environment where viewing opportunities for astronomers and space enthusiasts are very limited.  There are neat programs like Stellarium that allow you to view the night sky on your computer but they are not very immersive.  Having some experience with VR and stellar data I thought this would be a great opportunity to help satisfy that need.  

## What it does
It takes data from the HYG Star Database and allows the user to visualize the night sky as they would expect it look in an area with very little light pollution.  You can see the video for it in action...

[![Alt text](https://img.youtube.com/vi/ibaOJzUnTQU/0.jpg)](https://www.youtube.com/watch?v=ibaOJzUnTQU&feature=youtu.be)

(Click above image to see video)

## How I built it
First I had to find a dataset of Stars to use.  I decided on the HYG (Hipparcos, Yale Bright Star, and Gliese catalogs) stellar database.  It includes global position x,y,z coordinates, right ascension and declination positions, as well as stellar magnitude.  With these parameters you have all you need to plot Stars in the night sky.  For now I am just taking the x,y,z coordinates and normalizing the positions to a sphere (which is consistent with how our stellar coordinate systems currently work).  Then I made a rough formula that relates magnitude to the visibility of the star.  Eventually I want to play with star sizes as well.  Once the stars were in place I threw in a VR controller prefab and wrote the code for the movement.

## Challenges I ran into
Configuration was the hardest part with getting virtual reality setup.  The Oculus quest integration with Unity is fantastic and the library tools work great.  However, downloading android libraries, configuring .Net/Mono toolchains, and configuring build settings took a significant amount of time.

Additionally, I spend a significant time trying to implement local coordinates from the global.  In theory you should be able to take the global coordinates from the RA/DEC along with Lat/Long to calculate where the stars would appear at the current location.  However, this proved very difficult with some fairly advance math.  I hope to be able to get this working eventually. 

## Accomplishments that I'm proud of
I managed to get CSV parsing of the dataset working and was able to plot the data successfully in a scientifically accurate and visually pleasing way.  I managed to get VR controls working with the planetarium as well which allows users to rotate the night sky as they see fit.  It was a lot of different pieces that came together with VR, a little statistics, and Unity to create something that I am pretty proud of.

## What I learned
I learned a lot about how Unitys VR system is setup and some of the finer idiosyncrasies associated with setting up a VR project.  While I had some experience with this previously I did not have 

## What's next for Virtual Reality Planetarium
There are several more tasks that I want to accomplish.
1) Local coordinates along with ability to select location
2) Ambient music.  Might compose this or get a friend to compose it.
3) Nicer flooring
4) Planetary motion and orbits.  This would be another day in and of itself due to the math required to go from orbital parameters to cartesian (x, y, z) coordinates. 

