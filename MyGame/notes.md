Interesting changes:
- Caps convention: C# methods start with a cap, C++ start w/ lower.
  - Naming conventions in general are different.
- Properties vs. get/set methods in SFML
  - These feel inconsistent, and need to be unified in the GameEngine, too.
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
- VS 2019 vs 2022?
- Want this to work on the Macs?
- Solution orginization
  - make sure Resources is right
  - How about the rest of the repo? Readme's, etc.
  - Any other solution settings?
