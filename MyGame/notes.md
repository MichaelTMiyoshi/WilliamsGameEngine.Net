C++ version: https://github.com/MichaelTMiyoshi/WilliamsGameEngineVS2019

This is built w/ VS2022.

Interesting changes from the C++ version:
- Caps convention: C# methods start with a cap, C++ start w/ lower.
  - Naming conventions in general are different.
- Properties vs. get/set methods in SFML
  - SFML.Net adopts properties for some things, like sprite position.
- Removed the unused handleEvents thing
  - RenderWindow::pollEvent() is protected in SFML.Net, so not accesable.
  - Hacked it to work, and it did, but it seems unnecessary and inefficient.
  - Dropped it in favor of actual event handlers. Implemented for window close.
- Added SFML.Net 2.5.0 via NuGet, super-easy
- Overall, conversion was pretty easy. Mostly rote C++ -> C# syntax since the SFML bindings were so similar.
  - Kept as many comments as possible.
  - Kept impl as close as possible. Most functions are exactly the same except for minor syntax.
  - Ordering and naming convention are different.


TODOs:
- Want this to work on the Macs?
  - We think so. I need to dig into that, it's not straightforward sadly. 
- Solution orginization
  - Any other solution settings?
    - Turn off those perf windows when running?